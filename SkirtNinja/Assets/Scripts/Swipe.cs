using UnityEngine;
using System.Collections;
using Miscelaneo;

namespace Swipe{
	public class Swipe : MonoBehaviour {
		//posiciones del mouse
		public float  Xinicial = 0, XFinal = 0, YInicial = 0, YFinal = 0;
		//animator de la chica de vestida a desnuda
		public Animator ani;
		//contador de los swipes
		private int swipes;
		//prefab chica
		public GameObject player;
		//contador del tiempo que se queda parada cuando el swipe es incorrecto
		private float contador = 3;
		//sabes si al chica esta atenta
		private bool atenta;
		//true si se puede hacer swipe
		private bool correcto;

		public GameObject chica;


		void Start () {
			ani = GetComponent<Animator> ();
		}

		void Update () {
			StartCoroutine ("SwipeDestroy");
			if(player.GetComponent<Movimiento.MovimientoAutomatico>().swipeCorrecto){
				ani.SetBool("Parada",true);
			}else{
				ani.SetBool("Parada",false);
			}
			Atenta ();
			correcto = player.GetComponent<Movimiento.MovimientoAutomatico> ().swipeCorrecto;
		}

		//capturar las posiciones x e y del mouse cuandos se hace click
		void OnMouseDown(){
			Xinicial = Input.mousePosition.x;
			YInicial = Input.mousePosition.y; 
		}

		//comparar las posicion del mouse, cuando se deja de hacer click, para ver si se realizo un swipe y si este es correcto
		void OnMouseUp(){
			XFinal = Input.mousePosition.x;
			YFinal = Input.mousePosition.y;

				// hacia la derecha		hacia la izquierda			hacia arriba					hacia abajo                  
			if ((Xinicial+50 < XFinal || Xinicial-50 > XFinal || YInicial+16 < YFinal || YInicial-16 > YFinal) && (correcto) && !ani.GetBool("Swipe1")) //Si el swipe es horizontal o vertical
			{
				Camera.main.GetComponent<Tiempo>().swipe = true;
				//si el swipe es valido se ejecuta
				ani.SetBool("Swipe1",true);
				swipes += 1;
				player.GetComponent<Movimiento.MovimientoAutomatico>().sePuedeSeguirMoviendo = false;
			}
						//diagonal superior derecha										diagonal inferior derecha									 diagonal superior izquierda								 diagonal inferior izquierda
			if(((Xinicial+25 < XFinal && YInicial > YFinal+8) || (Xinicial+25 < Xinicial && YInicial < YFinal-8) || (Xinicial+25 < XFinal && YInicial < YFinal+8) || (Xinicial - 25 > XFinal && YInicial > YFinal-8)) && (correcto) && !ani.GetBool("Swipe1")) //Si el swipe es en diagonal
			{
				Camera.main.GetComponent<Tiempo>().swipe = true;
				//si el swipe es valido se ejecuta
				ani.SetBool("Swipe1",true);
				swipes += 1;
				player.GetComponent<Movimiento.MovimientoAutomatico>().sePuedeSeguirMoviendo = false;
			}

				//si el swipe es correcto pero la chica esta atenta se resta una vida al jugador
			if ((Xinicial+50 < XFinal || Xinicial-50 > XFinal || YInicial+16 < YFinal || YInicial-16 > YFinal)&& (!correcto)&& !ani.GetBool("Swipe1")) //Si el swipe es horizontal o vertical
			{
				Camera.main.GetComponent<Miscelaneo.Tiempo>().vidasJugador--;
				Camera.main.GetComponent<Stunned>().atenta = true;
				atenta = true;
			}
			else if(((Xinicial+25 < XFinal && YInicial > YFinal+8) || (Xinicial+25 < Xinicial && YInicial < YFinal-8) || (Xinicial+25 < XFinal && YInicial < YFinal+8) || (Xinicial - 25 > XFinal && YInicial > YFinal-8)) && (!correcto)&& !ani.GetBool("Swipe1"))//Si el swipe es en diagonal
			{
				Camera.main.GetComponent<Miscelaneo.Tiempo>().vidasJugador--;
				atenta = true;
			}
		}//metodo

		private void Atenta(){
			if (atenta) {
				if(contador > 0)
					contador -= Time.deltaTime;
					
					
				if(contador < 0){
					player.GetComponent<Movimiento.MovimientoAutomatico>().enabled = true;
					contador = 3;
					atenta = false;
					ani.SetBool("Atenta",false);
					chica.GetComponent<Swipe>().enabled = true;
					Camera.main.GetComponent<Stunned>().atenta = false;
				}
			}
		}
		//si la chica cambia a la animacion en que esta desnuda se hace un fade out hasta que es destruida
		private IEnumerator SwipeDestroy(){
			if (ani.GetBool("Swipe1")){
				player.GetComponent<Movimiento.MovimientoAutomatico>().velocidad = 0;
				yield return new WaitForSeconds(0.5f);
				this.renderer.material.color -= Color.white * Time.deltaTime/1.3f;
				yield return new WaitForSeconds(1f);
			}
		}
	}
}
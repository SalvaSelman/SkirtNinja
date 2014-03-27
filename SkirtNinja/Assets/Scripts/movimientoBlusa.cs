/**
 * Despues del swipe la ropa se mueve
 * se baja el alfa hasta llegar a 0 y luego 
 * se destruye
 */
using UnityEngine;
using System.Collections;
using Swipe;

namespace Movimiento {
	public class movimientoBlusa : MonoBehaviour {

		//velocidad a la que se mueve la ropa despues del swipe
		private float velocidad = 7.0f;
		//animator para saber si la chica esta desnuda o no
		public Animator blusa;
		//variable del tipo Swipe para poder obtener las posiciones del mouse
		public Swipe.Swipe sw;

		private Vector3 direccion;
		float XInicial, XFinal,YInicial,YFinal;
		
		void Update () {
			if(blusa.GetBool("Swipe1") == true){
				//esto hace que la blusa no se devuelva cuando llega al limite
				if(velocidad < 0)
					velocidad = 0;
				DireccionMovimiento();
			}
		}

		//movimiento de las prenda de ropa
		public void DireccionMovimiento(){

			//posiciones del mouse
			XInicial = sw.Xinicial;
			XFinal = sw.XFinal;
			YFinal = sw.YFinal;
			YInicial = sw.YInicial;
			//cuando el swipe cubre el tamaño correcto empieza a moverse la blusa
			if(transform.position.x > -600){

			//MOVIMIENTOS
				//derecha
				if (XInicial+50 < XFinal){
					//movimiento de las prendas
					transform.Translate(Vector3.right * (Time.deltaTime * velocidad));
					//fadeout de la ropa
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					//aumenta la velocidad en la que se mueven las prendas
					velocidad -= 0.02f;
				}
				//izquierda
				if(XInicial-50 > XFinal){
					transform.Translate(Vector3.left * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//arriba
				if(YInicial+16 < YFinal) {
					transform.Translate(Vector3.up * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//abajo
				if(YInicial-16 > YFinal){
					transform.Translate(Vector3.down * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				}
				//superior derecha
				if(XInicial+50 < XFinal && YInicial > YFinal+300){
					direccion = Vector3.up + Vector3.right;
					direccion = direccion.normalized;
					transform.Translate(direccion * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//inferior derecha
				if (XInicial+50 < XInicial && YInicial < YFinal-300){
					direccion = Vector3.down + Vector3.right;
					direccion = direccion.normalized;
					transform.Translate(direccion * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//superior izquierda
				if(XInicial+50 < XFinal && YInicial < YFinal+300){
					direccion = Vector3.up+Vector3.left;
					direccion = direccion.normalized;
					transform.Translate(direccion * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//inferior izquierda
				if(XInicial - 50 > XFinal && YInicial > YFinal-300)	{
					direccion = Vector3.down + Vector3.left;
					direccion = direccion.normalized;
					transform.Translate(direccion * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				}
			}
		}
	}
}
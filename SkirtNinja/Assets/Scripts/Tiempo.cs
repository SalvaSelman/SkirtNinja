/**
 * Este script es el que tiene mayor "control" sobre el juego
 * pese a que se llame Tiempo, controla animaciones, 
 * swipes, el tiempo, las vidas del jugador, entre otas cosas 
 */
using UnityEngine;
using System.Collections;

namespace Miscelaneo{
	public class Tiempo : MonoBehaviour {
		//tiempo el timer del juego
		public float tiempo;
		//atras es lo que dura la animacion ready (4 segundos)
		private float atras = 4f;
		//vidas del jugador
		public int vidasJugador = 3;
		//contador de los swipe
		public int swipes = 0;
		//contador de chicas en pantalla
		public int chicasEnPantalla = 0;
		//variable para detener la musica
		public AudioSource musica;
		//variable para enviar si el swipe es valido o no
		public bool swipeValido;
		//contador de cuantos swipes se tienen que hacer para ganar
		public int contadorWin = 7;
		//contador para los swipes incorrectos
		public int contadorMalSwipe = 0;
		//obtencion del genero del jugador
		public string genero;
		//objetos ready, youLose y youWin
		public GameObject ready,youLose,youWin;
		//variable para evitar que se cree infinitamente YouLose
		private float a;
		//swipe para hacer aparecer las prendas
		public bool swipe;
		//ropa de la chica
		public SpriteRenderer blusa, falda;
		//animator de la barra de tiempo
		public Animator barraTiempo;
		void Start () {
			genero = ready.GetComponent<Genero> ().genero;
			blusa.enabled = false;
			falda.enabled = false;
		}

		void Update () {
			//el cronometro empieza a funcionar cuando la imagen ready es destruida
			if(atras <= 0 && tiempo > 0  && tiempo<100)
				tiempo -= Time.deltaTime;
			//mientras se esta mostrando la animacion atras disminuye
			if(atras > 0)
				atras -= Time.deltaTime;
			// si atras es menor que 0  la animacion termino y se destruye
			if(atras < 0){
				atras = 0;
				ReadyGo ();
			}
			TimeOut();
			Win ();
			if (Camera.main.GetComponent<Tiempo> ().swipe) {
				blusa.enabled = true;
				falda.enabled = true;	
			}

			barraTiempo.SetInteger ("Tiempo", (int)tiempo);
		}

		//se muestra el cronometro una vez que la animacion ready es destruida
		//y que el cronometro sea mayor a 0
		void OnGUI(){
			//fuente del boton
			GUI.skin.button.fontSize = 35;
			//si se acaba el tiempo fin del juego
			if (tiempo <= 0) {
				if(GUI.Button(new Rect(35,0.15f*Screen.height,0.9f*Screen.width,100),"Try Again")){
					Application.LoadLevel(1);
				}
			}
			//si se hacen los swipes necesarios y no se ha acabado el tiempo se gana
			if (swipes == contadorWin && tiempo != 0) {
				if(GUI.Button(new Rect(35,0.1f*Screen.height,0.9f*Screen.width,100), "Well done!\nPlay Again")){
					Application.LoadLevel(1);
				}
			}
		}
	
		//destruccion de ready
		void ReadyGo(){
			Destroy (ready);
		}

		//cuando se acaba el tiempo, sale la animacion de you lose
		private void TimeOut(){
			if (tiempo < 0 || vidasJugador < 0){
				Camera.main.GetComponent<Spawn.SpawnChicas>().enabled = false;
				if(a > -1)
				{
					Instantiate(youLose,new Vector3(-6.29654f,2.167042f,-3f),Quaternion.identity);
					a = -1;
				}
				tiempo = 0;
				//musica.enabled = false;
				musica.volume -=Time.deltaTime;
			}
		}

		//cuando se hacen los swipes correspondiente sale la animacion de you win
		private void Win(){
			if (swipes >= contadorWin && tiempo > 0 && tiempo < 100 || tiempo < 0) {
				Instantiate(youWin, new Vector3(-6.29654f,2.167042f,-3f),Quaternion.identity);
				Time.timeScale = 0;
				tiempo = 101;
				//musica.enabled = false;
				if(GUI.Button(new Rect(35,0.1f*Screen.height,0.9f*Screen.width,100),"Play Again")){
					Application.LoadLevel(1);
					Time.timeScale = 1;
				}
			}
		}
	}
}

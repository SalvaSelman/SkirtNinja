using UnityEngine;
using System.Collections;
using Miscelaneo;

namespace Movimiento{
	public class MovimientoAutomatico : MonoBehaviour {

		//velocidad a la que se mueven las chichas
		public float velocidad;
		//si se detienen y donde se detienen
		public float detencion;
		//cuanto dura la detencion en caso que se detengan
		private float duracionDetencion;
		//velocidad actual del las chicas
		private float velocidadActual;
		//devuelve true si se puede hacer swipe
		public bool swipeCorrecto;
		//lugar donde hace spawn
		public int sp;
		//direccion a donde van luego de hacer el spawn
		public Vector3 direccion;
		//esta atenta?
		public bool atenta = false;
		//contador
		public float contador;
		//prefab chica
		public GameObject personaje;
		//si ya se realizo el swipe no se puede seguir moviendo 
		public bool sePuedeSeguirMoviendo = true;
		//animacion para saber si se puede seguir moviendo
		public Animator a;

		//asignacion de valores a variables
		void Start(){
			velocidad = Random.Range (2, 5);
			detencion = Random.Range (1.0f, 5.0f);
			contador = detencion;
			duracionDetencion = Random.Range (1.0f,3.5f);
			sp = Camera.main.GetComponent<Spawn.SpawnChicas> ().spawPoint;
			a = GetComponent<Animator> ();
		}

		//ejecucion de metodos
		void Update(){
			AutoMove ();
			StartCoroutine ("Detencion");
			//Debug.Log (sePuedeSeguirMoviendo);
		}

		//hace las chicas se muevan solas
		void AutoMove(){
			//segun el spawnpoint es la direccion en la cual se moveran
			if(sePuedeSeguirMoviendo){
				if(!a.GetBool("Atenta")){
					if(sp == 1 ){//arriba derecha
						direccion = Vector3.left * 4 + Vector3.down;// / 2.3f + Vector3.back;
						direccion = direccion.normalized;
						transform.Translate (direccion * (Time.deltaTime * velocidad));
					}
					if (sp == 2) {//abajo
						direccion = Vector3.left * 10 + Vector3.up * 2.3f;// / 2.5f + Vector3.forward*4; 
						direccion = direccion.normalized;
						transform.Translate(direccion * (Time.deltaTime * velocidad/1.1f));
					}
					if(sp == 3){//arriba izquierda
						direccion = Vector3.left * 4 + Vector3.down;// /2.5f + Vector3.forward;
						direccion = direccion.normalized;
						transform.Translate(direccion * (Time.deltaTime * velocidad));
					}
				}
			}
		}

		//detencion y duracion de la detencion
		private IEnumerator Detencion(){
			//velocidad acutal es la velocidad con la que empieza la chica
			if (velocidad != 0){
				//guardo la velocidad para asignarla de nuevo cuando termine la espera
				velocidadActual = velocidad;
				//animacion de la chica caminando

			}
			if (detencion >= 2 || contador > 0) {
				//esperar hasta cuando es la detencion
				yield return new WaitForSeconds(detencion);
				//detener el movimiento de la chica
				velocidad = 0;
				//swipe correcto hace el cambio de ropa
				swipeCorrecto = true;
				//esperar hasta que se termine la detencion
				yield return new WaitForSeconds(duracionDetencion);
				atenta = false;
				//devuelvo el valor actual de movimiento
				velocidad = velocidadActual;
			}
			detencion = -1;
			swipeCorrecto = false;
		}
	}
}
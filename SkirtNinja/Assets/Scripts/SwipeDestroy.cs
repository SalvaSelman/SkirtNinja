/**Este script esta en el objeto chica dentro
 * del prefab Personaje
 * */
using UnityEngine;
using System.Collections;
using Miscelaneo;
using Movimiento;

namespace Miscelaneo{
	public class SwipeDestroy : MonoBehaviour {

		//animacion de las chicas de vestidas a desnudas
		public Animator animator;
		//objeto de las chichas, para poder destruirlas despues del swipe
		public GameObject chica;
		//cantidad de swipes para ser desnudadas
		public int hits;
		public bool swipeCorrecto = false;

		void Start(){
		}

		void Update () {
			StartCoroutine("Destroy");
			FueraDeLaPantalla ();
			TimeOut ();
		}

		//espera antes de la destruccion del objeto
		private IEnumerator Destroy(){
			if(animator.GetBool("Swipe1")){
				yield return new WaitForSeconds(2f);
				Destroy(this.gameObject);
				//contador de las chicas a las que se les hizo swipe
				Camera.main.GetComponent<Miscelaneo.Tiempo>().swipes++;
				//contador de las chicas en pantalla
				Camera.main.GetComponent<Miscelaneo.Tiempo>().chicasEnPantalla--;
			}
		}

		//destruirlas cuando salen de la pantalla
		private void FueraDeLaPantalla(){
			//chicas de mas atras 
			if(chica.transform.position.x <= -16  || chica.transform.position.x >= 3f){
				Destroy(this.gameObject);
				//contador de las chicas en pantalla
				Camera.main.GetComponent<Miscelaneo.Tiempo>().chicasEnPantalla--;
			}
			//chicas de adelante
			if(chica.transform.position.x <= -16  || chica.transform.position.x >= 3 ){
				Destroy(this.gameObject);
				//contador de las chicas en pantalla
				Camera.main.GetComponent<Miscelaneo.Tiempo>().chicasEnPantalla--;
			}
		}

		//destruccion de todas
		public void TimeOut(){
			if (Camera.main.GetComponent<Tiempo> ().tiempo <= 0 || Camera.main.GetComponent<Tiempo>().swipes == Camera.main.GetComponent<Tiempo>().contadorWin) {
				Destroy(this.gameObject);
			}
		}
	}
}

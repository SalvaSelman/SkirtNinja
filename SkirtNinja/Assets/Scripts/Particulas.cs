using UnityEngine;
using System.Collections;

namespace Miscelaneo{
public class Particulas : MonoBehaviour {
		//objeto particulas
		public ParticleSystem particulas;
		//detector de click
		private bool click;

		private void Update(){
			MovimientoParticulas ();
			if (click) {
				//la posicion de las particulas es ajustadas a la posicion del mouse
				particulas.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15));
			}
			particulas.startRotation = 10;
		}

		//activacion de las particulas
		private void MovimientoParticulas(){
			// si es que se esta haciendo click
			if(Input.GetMouseButtonDown(0)){
				//activo particulas 
				particulas.enableEmission = true;
				//y dejo click en true
				click = true;
			}
			if (Input.GetMouseButtonUp(0)) {
				//cuando deja de hacer click dejo todo en false
				particulas.enableEmission = false;
				click = false;
			}
		}
	}
}

/**	
 * 		Dejo la variable click en true y luego la comparo en el update para 
 * 		que en la posicion de las particulas vayan cambiando durante cada, 
 *		de no hacerlo de esta forma se queda en la posicion donde se hizo 
 *		el click, no se mueven y cuando se deja de hacer click desaparecen.
 *
 *		para ajustar la posicion de las particulas tengo que hacerlo con 
 *		Camera.main.ScreenToWorldPoint (Vector 3), ya que funcionan con
 *		medidas distintas.
 */
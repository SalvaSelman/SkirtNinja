/**
 * codigo escena splash
 */

using UnityEngine;
using System.Collections;

namespace Miscelaneo{
	public class ToGame : MonoBehaviour {
		//tiempo de espera para activar los botones
		private float tiempo;
		//pasar la variable de genero a tiempo atraves de ready
		public GameObject ready;


		/*public void Awake(){
			DontDestroyOnLoad (transform.gameObject);
		}*/

		private void Start(){
			tiempo = 4f;
		}

		private void Update(){
			if(tiempo > 0)
				tiempo -= Time.deltaTime;
			if(tiempo < 0 && Input.GetMouseButtonDown(0))
				Application.LoadLevel(2);
		}
	}
}
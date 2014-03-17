using UnityEngine;
using System.Collections;
using Miscelaneo;

namespace Spawn{
	public class SpawnChicas : MonoBehaviour {
		//creacion de los objeto chico y chica
		public GameObject chicaPrefab,chicoPrefab;
		//lugar de creacion
		public int spawPoint;
		//posicion de cada spawnPoint
		private Vector3 position;
		//tiempo de espera antes de el primer spawn
		private float tiempo = 3;
		//cada cuanto tiempo van a hacer spawn
		private float velocidadSpawn = 2;
		//obtencion del genero
		public string genero;
		
		void Update () {
			//no se crean objetos mientras una vez que el tiempo a 0 o que ya hayan 3 chicas en pantalla
			if ((tiempo <= 0) && (Camera.main.GetComponent<Miscelaneo.Tiempo>().tiempo != 0) && (Camera.main.GetComponent<Miscelaneo.Tiempo>().chicasEnPantalla <= 3)) {
				//creacion del objeto
				//if(string.Compare(Camera.main.GetComponent<Miscelaneo.Tiempo>().genero,"femenino") == 0){	
					Spawn (chicaPrefab);
				//}
				//aumento en 1 el contador de las chicas
				Camera.main.GetComponent<Miscelaneo.Tiempo>().chicasEnPantalla++;

				tiempo = velocidadSpawn;
				velocidadSpawn -= 0.05f;
				//la no pueden hacer spawn con un tiempo menor a 0.7
				if(velocidadSpawn <= 0.7f){
					velocidadSpawn = 0.7f;
				}

			}
			tiempo -= Time.deltaTime;
		}
		//creacion de las chicas
		private void Spawn(GameObject objeto){
			//eleccion de una posicion random
			int posicion = 2;//Random.Range(1,4);
			spawPoint = posicion;
			if(posicion == 1){
				Instantiate(objeto,new Vector3 (0.7878923f,-3.037436f,8),Quaternion.identity) ;
				Camera.main.GetComponent<Miscelaneo.Tiempo>().chicasEnPantalla++;
				Camera.main.GetComponent<Tiempo>().swipe = false;
			}
			if (posicion == 2) {
				Instantiate(objeto, new Vector3(2,-6f,10),Quaternion.identity);
				Camera.main.GetComponent<Miscelaneo.Tiempo>().chicasEnPantalla++;
				Camera.main.GetComponent<Tiempo>().swipe = false;
			}
			if (posicion >= 3) {
				Instantiate(objeto, new Vector3(3,2.223358f,8),Quaternion.identity);
				Camera.main.GetComponent<Miscelaneo.Tiempo>().chicasEnPantalla++;
				Camera.main.GetComponent<Tiempo>().swipe = false;
			}
		}
	}
}
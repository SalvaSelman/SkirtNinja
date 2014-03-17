using UnityEngine;
using System.Collections;
using Miscelaneo;

namespace HP{
	public class VidaJugador : MonoBehaviour {
		//Vidas que tiene el jugador
		public int vidas = 10;
		public bool swipeValido = false;
		void Start () {
		}
		void Update () {
			ToLose ();
		}

		//si las vidas llegan a 0 sale la pantalla de you lose
		private void ToLose(){
			if (vidas < 0) {
				Miscelaneo.SwipeDestroy lose = new Miscelaneo.SwipeDestroy();
				lose.TimeOut();
			}
		}
	}
}
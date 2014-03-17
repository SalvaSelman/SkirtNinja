using UnityEngine;
using System.Collections;

namespace Miscelaneo{
	public class Pausa : MonoBehaviour{
		private bool pausa = false;
		public GameObject chica;
		public AudioSource musica;
		private int mp;

		void Update(){
			//si se activa la pausa
			if (pausa) {
				Time.timeScale = 0;
				chica.GetComponent<SwipeDestroy>().enabled = false;
				musica.Pause();
			}
			if(!pausa){
				Time.timeScale = 1;
				chica.GetComponent<SwipeDestroy>().enabled = true;
				if ( !musica.isPlaying ) 
					musica.Play ();
			}
		}

		void OnGUI(){
			if(GUI.Button (new Rect((Screen.width*0.97f)-130, 35, 110, 40),"",GUIStyle.none)){
				pausa = !pausa;
			}
		}
	}
}
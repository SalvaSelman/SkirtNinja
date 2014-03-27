using UnityEngine;
using System.Collections;

namespace Miscelaneo{
	public class WinLose : MonoBehaviour {

		public int win,lose;
		void Start () {
			win = 0;
			lose = 0;
		}
	
		void Update () {
			//Debug.Log ("win: " + win + " - lose: " + lose);
		}

		private void GanarOPerder(){
			if (win == 3 || lose == 3) {
				Application.LoadLevel(0);
			}
		}
	}
}

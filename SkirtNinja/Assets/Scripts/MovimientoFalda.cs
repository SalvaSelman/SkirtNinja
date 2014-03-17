using UnityEngine;
using System.Collections;
using Swipe;

namespace Movimiento{
	public class MovimientoFalda : MonoBehaviour {
		
		//velocidad de movimiento
		private float velocidad = 7.0f;
		//animator para saber cuando esta desnuda la chica
		public Animator blusa;

		//
		public Swipe.Swipe sw;
		public int a;
		
		float XInicial, XFinal,YInicial,YFinal;
		
		void Update () {
			
			if(blusa.GetBool("Swipe1") == true){
				//esto hace que la blusa no se devuelva cuando llega al limite
				if(velocidad < 0)
					velocidad = 0;
				DireccionMovimiento();
			}
		}
		public void DireccionMovimiento(){
			XInicial = sw.Xinicial;
			XFinal = sw.XFinal;
			YFinal = sw.YFinal;
			YInicial = sw.YInicial;
			//cuando el swipe cubre el tamaño correcto empieza a moverse la blusa
			if(transform.position.x > -600){
				//derecha
				if (XInicial+50 > XFinal){
					transform.Translate(Vector3.right * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				}
				//izquierda
				if(XInicial-50 < XFinal){
					transform.Translate(Vector3.left * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//arriba
				if(YInicial+16 > YFinal) {
					transform.Translate(Vector3.up * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//abajo
				if(YInicial-16 < YFinal){
					transform.Translate(Vector3.down * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				}
				//superior derecha
				if(XInicial+50 > XFinal && YInicial < YFinal+300){
					transform.Translate(Vector3.up * (Time.deltaTime * velocidad));
					transform.Translate (Vector3.right * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//inferior derecha
				if (XInicial+50 > XInicial && YInicial > YFinal-300){
					transform.Translate(Vector3.down * (Time.deltaTime * velocidad));
					transform.Translate(Vector3.right * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//superior izquierda
				if(XInicial+50 > XFinal && YInicial > YFinal+300){
					transform.Translate(Vector3.up * (Time.deltaTime * velocidad));
					transform.Translate(Vector3.left * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				} 
				//inferior izquierda
				if(XInicial - 50 < XFinal && YInicial < YFinal-300)	{
					transform.Translate(Vector3.down * (Time.deltaTime * velocidad));
					transform.Translate(Vector3.left * (Time.deltaTime * velocidad));
					renderer.material.color -= Color.white * Time.deltaTime / 2;
					velocidad -= 0.02f;
				}
			}
		}
	}
}
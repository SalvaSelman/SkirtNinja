using UnityEngine;
using System.Collections;

public class VidaNinja : MonoBehaviour {
	private Animator ani;



	private void Start(){
		ani = GetComponent<Animator>();
	}

	private void Update(){
	}

	//cambio de la animacion de la cara del ninja a medida que se van perdiendo vidas
	private void OnGUI(){
		ani.SetInteger ("Vida", Camera.main.GetComponent<Miscelaneo.Tiempo> ().vidasJugador);
	}
}
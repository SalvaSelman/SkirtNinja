using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour {
	public Animator animator;

	//cambiar la imagen de los corazones a medida que el jugador va perdiendo las vidas
	void Update () {
		animator.SetInteger ("Vida", Camera.main.GetComponent<Miscelaneo.Tiempo> ().vidasJugador);
	}
}

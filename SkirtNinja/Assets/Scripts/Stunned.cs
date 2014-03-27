using UnityEngine;
using System.Collections;

public class Stunned : MonoBehaviour {

	public bool atenta;
	public Animator ani;
	public GameObject player;

	private void Update(){
		if (atenta) {
			StartCoroutine("Shake");
		}
	}

	private IEnumerator Shake()
	{
		ani.SetBool("Atenta",true);
		player.GetComponent<Movimiento.MovimientoAutomatico>().enabled = false;
		Camera.main.transform.position = new Vector3(Random.Range(-6.2f,-6.45f),Camera.main.transform.position.y,Camera.main.transform.position.z);
		yield return new WaitForSeconds(1);
		Camera.main.transform.position = new Vector3(-6.35f,Camera.main.transform.position.y,Camera.main.transform.position.z);
		atenta = false;
		ani.SetBool("Atenta",false);
		atenta = false;
	}
}
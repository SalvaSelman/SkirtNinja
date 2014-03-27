using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {
	private float tiempo = 4.0f;
	public SpriteRenderer play;
	// Use this for initialization
	void Start () {
		play.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		tiempo -= Time.deltaTime;
		if(tiempo < 0)
			play.enabled = true;
	}

	private void OnGUI(){
		if (GUI.Button (new Rect (0.21f * Screen.width, 0.75f * Screen.height, 400, 120), "", GUIStyle.none)) {
			if(tiempo > 0)
				Application.LoadLevel (2);
		}
	}

	private IEnumerator EsperaBoton(){
		yield return new WaitForSeconds(5);
	}
}

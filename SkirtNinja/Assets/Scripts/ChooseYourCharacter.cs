using UnityEngine;
using System.Collections;

public class ChooseYourCharacter : MonoBehaviour {

	public GameObject ready;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void OnGUI(){
		if (GUI.Button (new Rect (50, 290, 550, 220),"",GUIStyle.none)){
			ready.GetComponent<Genero>().genero = "masculino";
			Application.LoadLevel(1);
		}
		if( GUI.Button (new Rect(50, 550, 550, 220 ),"",GUIStyle.none)){
			ready.GetComponent<Genero>().genero = "femenino";
			Application.LoadLevel(1);
		}
	}
}

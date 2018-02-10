using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubirCaixas : MonoBehaviour {

	public Text texto;
	private bool apertou = false;

	void Start () {
		
	}

	void Update () {
		
	}
	void OnTriggerStay(Collider hit){
		if (hit.CompareTag ("Player")) {
			texto.gameObject.SetActive (true);
			texto.text = "Aperte E para pular";
			if (Input.GetKey (KeyCode.E)) {
				apertou = true;
				hit.GetComponent<Move> ().SeMecher = false;
			}
			if (hit.CompareTag ("Player") && apertou) {
				hit.transform.Translate (new Vector3 (0, 0.1f, 0.1f));
			}
		}
	}
	void OnTriggerExit(Collider hit){
		if (hit.CompareTag ("Player")) {
			apertou = false;
			hit.GetComponent<Move> ().SeMecher = true;
			texto.gameObject.SetActive (false);
			texto.text = "Aperte E";
		}
	}
}

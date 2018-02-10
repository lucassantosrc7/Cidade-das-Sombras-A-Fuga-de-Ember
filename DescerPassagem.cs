using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescerPassagem : MonoBehaviour {

	public GameObject subida;
	public GameObject lugarPlayer;


	void Start () {
		
	}

	void Update () {
		
	}
	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("MainCamera") && Input.GetKey(KeyCode.W)) {
			subida.GetComponent<SubirPassagem> ().cam.SetActive (false);
			SubirPassagem.player.GetComponent<Move> ().SeMecher = true;
			SubirPassagem.player.GetComponent<Move> ().temCamera = true;
			SubirPassagem.entrou = false;
			SubirPassagem.player.transform.position = lugarPlayer.transform.position;
		}
	}
}

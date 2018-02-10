using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubirPassagem  : MonoBehaviour {

	public Text texto;
	public static bool entrou = false;
	public GameObject cam;
	public float speed;
	public static GameObject player;

	void Start () {
		cam.SetActive (false);
	}

	void Update () {
		if (entrou && Input.GetKey (KeyCode.W)) {
			cam.transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}else if (entrou && Input.GetKey (KeyCode.S)) {
			cam.transform.Translate (Vector3.back * Time.deltaTime * speed);
		}
	}
	void OnTriggerStay(Collider hit){
		if (hit.CompareTag ("MainCamera") && Input.GetKey(KeyCode.S)) {
			cam.SetActive (false);
			player.GetComponent<Move> ().SeMecher = true;
			player.GetComponent<Move> ().temCamera = true;
			entrou = false;
		}
		else if(Input.GetKey(KeyCode.E) && hit.CompareTag ("Player")){
			texto.gameObject.SetActive (true);
			texto.text = "Aperte E para pular";
			player = hit.gameObject;
			hit.GetComponent<Move> ().SeMecher = false;
			hit.GetComponent<Move> ().temCamera = false;
			cam.SetActive (true);
			entrou = true;
		}
	}
	void OnTriggerExit(Collider hit){
		if (hit.CompareTag ("Player")) {
			hit.GetComponent<Move> ().SeMecher = true;
		}
		texto.gameObject.SetActive (false);
		texto.text = "Aperte E";
	}
}

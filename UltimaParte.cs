using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimaParte : MonoBehaviour {

	public GameObject Encanador;

	void Start () {
		Encanador.SetActive (false);
	}
	

	void Update () {
		
	}
	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("EncanadorMestre")) {
			hit.gameObject.SetActive (false);
			Encanador.SetActive (true);
			Destroy (gameObject);
		}
	}
}

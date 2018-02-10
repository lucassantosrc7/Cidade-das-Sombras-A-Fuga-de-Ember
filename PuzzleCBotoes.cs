using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCBotoes : MonoBehaviour {

	public Camera cam;
	public bool desligado;
	public GameObject verde;
	public GameObject vermelho;

	void Update () {
		if (cam.gameObject.activeInHierarchy == true) {
			if (desligado) {
				vermelho.SetActive (true);
				verde.SetActive (false);
			} else {
				vermelho.SetActive (false);
				verde.SetActive (true);
			}
		}
	}

	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Meio")) {
			desligado = !desligado;
		}
	}
}

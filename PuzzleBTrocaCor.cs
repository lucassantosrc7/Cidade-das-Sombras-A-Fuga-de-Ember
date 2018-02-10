using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBTrocaCor : MonoBehaviour {

	public Camera cam;
	public GameObject ligado;
	public GameObject desligado;
	public bool vermelho;
	[HideInInspector]public bool clicou = false;
	[Space(20)]
	public GameObject[] polimento;

	void Awake(){
		for (int i = 0; i < polimento.Length; i++) {
			polimento[i].GetComponent<Renderer>().material.color = new Color32(111,111,111,111);
		}
	}

	void Update () {
		if (cam.gameObject.activeInHierarchy == true) {
			if (vermelho) {
				desligado.SetActive (true);
				ligado.SetActive (false);
			} else {
				desligado.SetActive (false);
				ligado.SetActive (true);
			}
		}
	}

	void OnMouseDown() {
		clicou = true;
	}
	void OnMouseEnter() {
		for (int i = 0; i < polimento.Length; i++) {
			polimento[i].GetComponent<Renderer>().material.color = new Color32(229,229,229,255);
		}
	}
	void OnMouseExit() {
		for (int i = 0; i < polimento.Length; i++) {
			polimento[i].GetComponent<Renderer>().material.color = new Color32(111,111,111,111);
		}
	}

}

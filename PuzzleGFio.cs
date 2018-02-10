using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGFio : MonoBehaviour {

	public Camera cam;

	private bool Emcima;
	public int num = 4;
	private float rotacao;

	void Start () {
		rotacao = 360 / num;
	}

	void Update () {

		if (cam.gameObject.activeInHierarchy == true) {
			if (Emcima && Input.GetMouseButtonDown(0)) {
				transform.Rotate (new Vector3 (0, rotacao, 0));
			}
		}
	}

	void OnMouseOver(){
		Emcima = true;
	}
	void OnMouseExit(){
		Emcima = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGColisor : MonoBehaviour {

	public enum Estado
	{
		Entrada,
		Saida,
		Nada
	}
	public Estado estado = Estado.Nada;
	public GameObject[] parsa;
	public GameObject pai;

	public bool energia = false;

	void Start () {
		
	}

	void Update () {
		
		if (energia) {
			GetComponent<Renderer> ().material.color = new Color32 (255, 0, 0, 255);

		} else {
			GetComponent<Renderer> ().material.color = new Color32 (9, 90, 9, 255);
		}
	}

	void OnTriggerStay(Collider hit){
		if (hit.CompareTag ("Comeco")) {
			energia = true;
			estado = Estado.Entrada;
			pai.GetComponent<Renderer> ().material.color = new Color32 (255, 0, 0, 255);
			for (int i = 0; i < parsa.Length; i++) {
				parsa [i].GetComponent<PuzzleGColisor> ().energia = true;
				if (parsa [i].GetComponent<PuzzleGColisor> ().estado != Estado.Entrada) {
					parsa [i].GetComponent<PuzzleGColisor> ().estado = Estado.Saida;
				}
			}
		}
		else if (hit.CompareTag ("Fio") && hit.GetComponent<PuzzleGColisor> ().energia && 
		   (hit.GetComponent<PuzzleGColisor> ().estado == Estado.Saida || hit.GetComponent<PuzzleGColisor> ().estado == Estado.Nada)) {
			energia = true;
			estado = Estado.Entrada;
			pai.GetComponent<Renderer> ().material.color = new Color32 (255, 0, 0, 255);
			for (int i = 0; i < parsa.Length; i++) {
				parsa [i].GetComponent<PuzzleGColisor> ().energia = true;
				if (parsa [i].GetComponent<PuzzleGColisor> ().estado != Estado.Entrada) {
					parsa [i].GetComponent<PuzzleGColisor> ().estado = Estado.Saida;
				}
			}
		} else if (hit.CompareTag ("Fio") && !hit.GetComponent<PuzzleGColisor> ().energia && hit.GetComponent<PuzzleGColisor> ().estado == Estado.Nada) {
			energia = false;
			estado = Estado.Nada;
			pai.GetComponent<Renderer> ().material.color = new Color32 (9, 90, 9, 255);
			for (int i = 0; i < parsa.Length; i++) {
				parsa[i].GetComponent<PuzzleGColisor> ().estado = Estado.Nada;
				parsa[i].GetComponent<PuzzleGColisor> ().energia = false;
			}
		}
	}

	void OnTriggerEnter(Collider hit){
		if(hit.CompareTag ("Fim") && energia){
			hit.GetComponent<Renderer> ().material.color = new Color32 (255, 0, 0, 255);
		}
	}

	void OnTriggerExit(Collider hit){
		for (int i = 0; i < parsa.Length; i++) {
			if ((hit.CompareTag ("Fio") || hit.CompareTag ("Comeco")) && energia && parsa[i].GetComponent<PuzzleGColisor> ().estado != Estado.Entrada) {
				energia = false;
				estado = Estado.Nada;
				pai.GetComponent<Renderer> ().material.color = new Color32 (9, 90, 9, 255);
				parsa[i].GetComponent<PuzzleGColisor> ().estado = Estado.Nada;
				parsa[i].GetComponent<PuzzleGColisor> ().energia = false;
			} else if((hit.CompareTag ("Fio") || hit.CompareTag ("Comeco")) && energia){
				estado = Estado.Saida;
			}
		}
		if(hit.CompareTag ("Fim")){
			hit.GetComponent<Renderer> ().material.color = new Color32 (0, 255, 0, 255);
		}
	}

}

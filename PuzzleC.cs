using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleC : MonoBehaviour {

	public GameObject[] Botoes;
	private bool todosVerdes;
	public Text texto;

	void Start () {
		
	}

	void Update () {
		
		//Saber se Ganhou
		for (int i = 0; i < Botoes.Length; i++) {
			if (Botoes [i].GetComponent<PuzzleCBotoes> ().desligado) {
				todosVerdes = false;
				i = Botoes.Length;
			} else {
				todosVerdes = true;
			}
		}

		//Condicão de vitoria
		if (todosVerdes) {
			texto.gameObject.SetActive (true);
			texto.text = "Venceu essa";
			Tudoaguado.P2 = true;
			StartCoroutine(Fecha ());
		}
	}
	IEnumerator Fecha(){
		yield return new WaitForSeconds (0.5f);
		texto.gameObject.SetActive (false);
		GetComponent<ComecarPuzzle> ().venceu = true;
		GetComponent<PuzzleC> ().enabled = false;
	}
}

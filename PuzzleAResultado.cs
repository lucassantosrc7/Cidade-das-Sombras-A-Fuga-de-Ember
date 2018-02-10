using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleAResultado : MonoBehaviour {

	public GameObject Botao1;
	public GameObject Botao2;
	public GameObject Botao3;
	public Text texto;

	void Start () {
		
	}

	void Update () {
		if (Botao1.GetComponent<PuzzleA> ().acertou && Botao2.GetComponent<PuzzleA> ().acertou && Botao3.GetComponent<PuzzleA> ().acertou) {
			texto.gameObject.SetActive (true);
			texto.text = "Venceu essa";
			Tudoaguado.P1 = true;
			StartCoroutine(Fecha ());
		}
	}

	IEnumerator Fecha(){
		yield return new WaitForSeconds (0.5f);
		texto.gameObject.SetActive (false);
		GetComponent<ComecarPuzzle> ().venceu = true;
		GetComponent<PuzzleAResultado> ().enabled = false;
	}
}

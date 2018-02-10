using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleB : MonoBehaviour {

	public Camera cam;

	public GameObject[] Botoes;
	private bool todosVerdes;
	private Color verde = new Color (0,1,0,1);

	public Text texto;

	void Update () {

		if (cam.gameObject.activeInHierarchy == true) {
			//Mudar de cor dos botoes
			for (int i = 0; i < Botoes.Length; i++) {
				if (Botoes [i].GetComponent<PuzzleBTrocaCor> ().clicou == true) {

					//Mudar do proprio Botão
					Botoes [i].GetComponent<PuzzleBTrocaCor> ().vermelho = !Botoes [i].GetComponent<PuzzleBTrocaCor> ().vermelho;

					//Mudar do botão da direita
					if (i + 1 < Botoes.Length && i != 3) {
						Botoes [i + 1].GetComponent<PuzzleBTrocaCor> ().vermelho = !Botoes [i + 1].GetComponent<PuzzleBTrocaCor> ().vermelho;
					}

					//Mudar do botão da esquerda
					if (i - 1 >= 0 && i != 4) {
						Botoes [i - 1].GetComponent<PuzzleBTrocaCor> ().vermelho = !Botoes [i - 1].GetComponent<PuzzleBTrocaCor> ().vermelho;
					}

					//Mudar do botão de baixo
					if (i + 4 < Botoes.Length) {
						Botoes [i + 4].GetComponent<PuzzleBTrocaCor> ().vermelho = !Botoes [i + 4].GetComponent<PuzzleBTrocaCor> ().vermelho;
					}

					//Mudar do botão de cima
					if (i - 4 >= 0) {
						Botoes [i - 4].GetComponent<PuzzleBTrocaCor> ().vermelho = !Botoes [i - 4].GetComponent<PuzzleBTrocaCor> ().vermelho;
					}

					Botoes [i].GetComponent<PuzzleBTrocaCor> ().clicou = false;
				}
			}

			//Saber se Ganhou
			for (int i = 0; i < Botoes.Length; i++) {
				if (Botoes [i].GetComponent<PuzzleBTrocaCor> ().vermelho) {
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
				Tudoaguado.P3 = true;
				StartCoroutine(Fecha ());
			}
		}
	}
	IEnumerator Fecha(){
		yield return new WaitForSeconds (0.5f);
		texto.gameObject.SetActive (false);
		GetComponent<ComecarPuzzle> ().venceu = true;
		GetComponent<PuzzleB> ().enabled = false;
	}
}

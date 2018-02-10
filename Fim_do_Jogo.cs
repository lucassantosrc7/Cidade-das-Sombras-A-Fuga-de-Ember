using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fim_do_Jogo : MonoBehaviour {

	public GameObject texto;

	public Image branco;
	private float tempo_Do_Fade = 10;
	private float fade;
	private float tempo;
	private float cor;

	private bool iniciar = false;
	private bool trocarCena = false;
	private bool tigger = true;

	void Start () {
		fade = (255 * 0.1f) / (tempo_Do_Fade/2);
		branco.gameObject.SetActive (false);
	}

	void Update () {
		if (iniciar) {
			cor += fade;
			branco.color = new Color32 (0, 0, 0, (byte)cor);
			if (cor >= 255) {
				iniciar = false;
				trocarCena = true;
				tempo = Time.time + 2f;
			}
		}
		if (trocarCena && Time.time > tempo) {
			SceneManager.LoadScene ("Menu");
		}
	}
	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Player")) {
			texto.gameObject.SetActive (true);
		}
	}

	void OnTriggerStay(Collider hit){
		if (hit.CompareTag ("Player") && Input.GetKeyDown (KeyCode.E) && tigger) {
			branco.gameObject.SetActive (true);
			texto.gameObject.SetActive (false);
			iniciar = true;
			tigger = false;
		}
	}
}

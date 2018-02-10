using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Esconderijo : MonoBehaviour {

	public Camera cam_Caixa;
	public Camera cam_Cano;
	public Text texto;
	public GameObject pos1;
	public GameObject pos2;
	private GameObject player;

	private bool apertar = true;
	private bool clicar = true;
	private bool dentro = false;

	void Start () {
		cam_Caixa.depth = -1;
		cam_Cano.depth = -1;
	}

	void FixedUpdate () {
		if (Input.GetMouseButtonDown (0) && clicar && player != null) {
			if (cam_Caixa.depth == 3) {
				cam_Cano.depth = 3;
				cam_Caixa.depth = -1;
				player.transform.position = pos1.transform.position;
				player.transform.eulerAngles = pos1.transform.eulerAngles;
			} else if (cam_Cano.depth == 3) {
				cam_Caixa.depth = 3;
				cam_Cano.depth = -1;
				player.transform.position = pos2.transform.position;
				player.transform.eulerAngles = pos2.transform.eulerAngles;
			}
			clicar = false;
		}else if (Input.GetMouseButtonUp (0) && !clicar) {
			clicar = true;
		}

	}

	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Player")){
			dentro = true;
			texto.text = "Aperte E para entrar";
			texto.gameObject.SetActive (true);
			player = hit.gameObject;
		}
	}
	void OnTriggerStay(Collider hit){
		if ((hit.CompareTag ("Player") || hit.CompareTag ("GameController")) && Input.GetKeyDown (KeyCode.E) && apertar) {
			if (dentro) {
				texto.text = "Clique para mudar de posiçao";
				dentro = false;
				player = hit.gameObject;
				player.GetComponent<Move> ().SeMecher = false;
				player.GetComponent<MeshRenderer> ().enabled = false;
				player.gameObject.tag = "GameController";
				player.transform.position = pos1.transform.position;
				player.transform.eulerAngles = pos1.transform.eulerAngles;
				cam_Caixa.depth = 3;
			} else if (!dentro) {
				texto.text = "Aperte E para entrar";
				dentro = true;
				player = hit.gameObject;
				player.GetComponent<Move> ().SeMecher = true;
				player.GetComponent<MeshRenderer> ().enabled = true;
				player.gameObject.tag = "Player";
				cam_Caixa.depth = -1;
				cam_Cano.depth = -1;
			}
			apertar = false;
		} else if ((hit.CompareTag ("Player") || hit.CompareTag ("GameController")) && Input.GetKeyUp (KeyCode.E) && !apertar) {
			apertar = true;
		}
	}

	void OnTriggerExit(Collider hit){
		if (hit.CompareTag ("Player")) {
			dentro = true;
			texto.text = "Aperte E";
			texto.gameObject.SetActive (false);
		}
	}
}

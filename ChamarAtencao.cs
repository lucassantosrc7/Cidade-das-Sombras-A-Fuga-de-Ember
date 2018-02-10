using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamarAtencao : MonoBehaviour {

	public enum Tipo
	{
		ExtourarAntes,
		ExtourarDepois,
	}

	public Tipo tipo;
	public GameObject [] particulas;
	public GameObject texto;
	public GameObject [] guarda;

	private AudioSource source;
	public AudioClip som;
	void Awake () {
		for (int j = 0; j < particulas.Length; j++) {
			particulas[j].SetActive (false);
		}
		source = GetComponent<AudioSource> ();
	}

	void Update () {
		
	}
	void OnTriggerStay(Collider hit){
		if (hit.CompareTag ("EncanadorMestre")) {
			for (int i = 0; i < guarda.Length; i++) {
                guarda[i].GetComponent<PathFindingWayPoints>().source.Stop();
                guarda [i].GetComponent<PathFindingWayPoints> ().enabled = false;
				guarda [i].GetComponentInChildren<Encanadores_Anim> ().estado = Encanadores_Anim.Estado.Nada;
			}
		}
		if(hit.CompareTag ("Player") && tipo == Tipo.ExtourarAntes){
			texto.gameObject.SetActive (true);
			if(Input.GetKey(KeyCode.E)){
				texto.gameObject.SetActive (false);
				for (int j = 0; j < particulas.Length; j++) {
					particulas[j].SetActive (true);
				}
				for (int i = 0; i < guarda.Length; i++) {
					guarda [i].GetComponent<PathFindingWayPoints> ().enabled = true;
				}
				texto.gameObject.SetActive (false);
				tipo = Tipo.ExtourarDepois;
				if (!source.isPlaying) {
					source.PlayOneShot (som);
				}
			}
		}
	}
	void OnTriggerExit(Collider hit){
		if (hit.CompareTag ("Player") && tipo == Tipo.ExtourarDepois) {
			for (int j = 0; j < particulas.Length; j++) {
				particulas[j].SetActive (true);
			}
			for (int i = 0; i < guarda.Length; i++) {
				guarda [i].GetComponent<PathFindingWayPoints> ().enabled = true;
			}
			if (!source.isPlaying) {
				source.PlayOneShot (som);
			}

		}
	}
}

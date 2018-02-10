using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vagalume_feat_Escada : MonoBehaviour {

	public enum Funcao
	{
		Ligar,
		Desligar,
	}
	public Funcao funcao;
	public GameObject vagalume;
	public GameObject p_Vagalume;
	private bool Subir;

	void Start () {
		
	}

	void Update () {
		if (Subir) {
			vagalume.transform.Translate (Vector3.up * Time.deltaTime * 7);
		}
		if (vagalume.transform.localPosition.y < 0 && p_Vagalume.transform.parent != null) {
			vagalume.transform.Translate (Vector3.up * Time.deltaTime * 1);
		}
	}
	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Player") && funcao == Funcao.Ligar) {
			Vagalume.melhorou = true;
			Vagalume.andar = true;
			p_Vagalume.transform.SetParent (hit.transform);
			Destroy (gameObject);
		} else if (hit.CompareTag ("Player") && funcao == Funcao.Desligar) {
			Vagalume.melhorou = false;
			p_Vagalume.transform.parent = null;
			Subir = true;
		}
	}
	void OnTriggerExit(Collider hit){
		if (hit.CompareTag ("Player")) {
			Vagalume.melhorou = false;
			vagalume.transform.position = new Vector3 (vagalume.transform.position.x, hit.transform.position.y, vagalume.transform.position.z);
			Destroy (gameObject);
		} else if (hit.CompareTag ("Vagalume")) {
			Subir = false;
			Escada.vagalume = hit.GetComponent<Vagalume>().pivot;
		}
	}
}

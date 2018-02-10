using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinamapaMove : MonoBehaviour {

    public GameObject Player;
	public GameObject [] ponto_de_referencia;
	private Vector3[] posInicial;
	private Vector3[] posFinal;
	public int raio = 15;
	public int i = 0;
	void Awake () {
		posInicial = new Vector3[ponto_de_referencia.Length];
		posFinal = new Vector3[ponto_de_referencia.Length];
		for (int j = 0; j < ponto_de_referencia.Length; j++) {
			posInicial[j] = ponto_de_referencia[j].transform.localPosition;
			posFinal[j] = ponto_de_referencia[j].transform.localPosition;
		}
	}
	
	void Update () {
		if (ponto_de_referencia.Length > 0) {
			if (posInicial [i].x > transform.position.x + raio) {
				posFinal [i].x = transform.position.x + raio;
			} else if (posInicial [i].x < transform.position.x - raio) {
				posFinal [i].x = transform.position.x - raio;
			} else {
				posFinal [i].x = posInicial [i].x;
			}

			if (posInicial [i].z > transform.position.z + raio) {
				posFinal [i].z = transform.position.z + raio;
			} else if (posInicial [i].z < transform.position.z - raio) {
				posFinal [i].z = transform.position.z - raio;
			} else {
				posFinal [i].z = posInicial [i].z;
			}
			//print (posInicial [i].z + " > ");
			//print (transform.position.z + raio);

			ponto_de_referencia [i].transform.position = posFinal [i];
		}
		transform.position = new Vector3(Player.transform.position.x,transform.position.y,Player.transform.position.z);
        transform.rotation = Player.transform.rotation;
	}
}

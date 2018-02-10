using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleG : MonoBehaviour {

	public GameObject[] Fins;
	public GameObject FimCerto;
	private Color vermelho = new Color (1,0,0,1);

	void Start () {
		
	}

	void Update () {
		//Saber se Ganhou
		if (FimCerto.GetComponent<Renderer> ().material.color == vermelho) {
			for (int i = 0; i < Fins.Length; i++) {
				if (Fins [i].GetComponent<Renderer> ().material.color == vermelho) {
					i = Fins.Length;
				} else {
					print ("Venceu");
				}
			}
		}
	}

}

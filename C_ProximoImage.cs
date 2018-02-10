using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_ProximoImage : MonoBehaviour {

	public Image[] concepts;
	private int num = 0;


	void Start () {
		
	}
	

	void Update () {
		print (num);
	}

	void DeixaVerdadeira(int n){
		concepts [n].gameObject.SetActive (true);
	}

	public void Proximo(){
		concepts [num].gameObject.SetActive (false);
		if (num < concepts.Length - 1) {
			num++;
		} else {
			num = 0;
		}

		DeixaVerdadeira (num);
	}
	public void Anterior(){
		concepts [num].gameObject.SetActive (false);
		if (num > 0) {
			num--;
		} else {
			num = concepts.Length - 1;
		}
		DeixaVerdadeira (num);
	}

}

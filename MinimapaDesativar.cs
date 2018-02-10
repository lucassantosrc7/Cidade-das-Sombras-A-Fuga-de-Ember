using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapaDesativar : MonoBehaviour {

	public GameObject obj_MP;

	void Start () {
		
	}

	void Update () {
		
	}
	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Player")) {
			obj_MP.SetActive (false);
		}
	}
}

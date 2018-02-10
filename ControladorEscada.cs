using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEscada : MonoBehaviour {

	public GameObject outro;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter(Collider hit){
		outro.SetActive (true);
		gameObject.SetActive (false);
	}
}

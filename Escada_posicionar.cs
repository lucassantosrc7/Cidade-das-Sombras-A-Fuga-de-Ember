using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada_posicionar : MonoBehaviour {

	void OnTriggerStay(Collider hit){
		if (hit.CompareTag ("Player")) {
			hit.transform.position = new Vector3 (transform.position.x, hit.transform.position.y, hit.transform.position.z);
		}
	}
}

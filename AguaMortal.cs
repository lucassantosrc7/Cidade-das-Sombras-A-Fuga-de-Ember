using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AguaMortal : MonoBehaviour {

	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Player")) {
			SceneManager.LoadScene("cena03");
		}
	}
}

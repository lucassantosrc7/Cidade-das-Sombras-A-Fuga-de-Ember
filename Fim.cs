using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fim : MonoBehaviour {

	public GameObject TextoDaVitoria;

	void OnTriggerEnter(Collider hit){
		if(hit.CompareTag("Player"))
		TextoDaVitoria.SetActive (true);
		StartCoroutine (Acabou ());
	}
	IEnumerator Acabou()
	{
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene ("Encanamento");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class G_ProximoOBJ : MonoBehaviour {

	private int numAtual = 1;
	public int numOBJ;
	private string estado;
	private float proxObj;
	private bool podeMecher = false;

	private AudioSource source;
	public AudioClip somClick;

	void Start () {
		source = GetComponent<AudioSource> ();
	}

	void Update () {
		
		if (estado == "+10" && proxObj > transform.position.x) {
			transform.Translate (Vector3.right);
			podeMecher = false;
		} else if (estado == "-10" && proxObj < transform.position.x) {
			transform.Translate (Vector3.left);
			podeMecher = false;
		} else if (estado == "+30" && proxObj > transform.position.x) {
			transform.Translate (Vector3.right);
			podeMecher = false;
		} else if (estado == "-30" && proxObj < transform.position.x) {
			transform.Translate (Vector3.left);
			podeMecher = false;
		} else
			podeMecher = true;


	}
	public void Proximo (){
		if (podeMecher) {
			if (numAtual < numOBJ) {
				estado = "+10";
				proxObj = transform.position.x + 10;
				numAtual++;
			} else {
				estado = "-30";
				proxObj = transform.position.x - 20;
				numAtual = 1;
			}
		}
	}
	public void Anterior (){
		if (podeMecher) {
			if (numAtual > 1) {
				estado = "-10";
				proxObj = transform.position.x - 10;
				numAtual--;
			} else {
				estado = "+30";
				proxObj = transform.position.x + 20;
				numAtual = numOBJ;
			}
		}
	}

	public void Voltar(){
		SceneManager.LoadScene ("Menu");
		Menu.chamar = Menu.Chamar.extras;
		source.PlayOneShot (somClick);
	}

	void OnTriggerEnter(Collider hit){
		hit.GetComponent<G_ExibirOBJ> ().mover = true;
		if (hit.GetComponentInChildren<Animator> () != null) {
			hit.GetComponentInChildren<Animator> ().enabled = true;
		}
	}

	void OnTriggerExit(Collider hit){
		hit.GetComponent<G_ExibirOBJ> ().mover = false;
		if (hit.GetComponentInChildren<Animator> () != null) {
			hit.GetComponentInChildren<Animator> ().enabled = false;
		}
		hit.gameObject.transform.eulerAngles = Vector3.zero;
	}
}

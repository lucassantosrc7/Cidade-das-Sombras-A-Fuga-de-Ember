using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encanadores_Anim : MonoBehaviour {

	public enum Estado
	{
		Nada,
		Andar,
		Vigiar,
		Idle,
		Fora,
	}
	[HideInInspector]public Estado estado = Estado.Nada;
	private Animator anim;
	public bool consertando;

	void Start () {
		anim = GetComponent<Animator> ();
		estado = Estado.Nada;
	}
	

	void Update () {
		if (consertando) {
			anim.GetComponent<Animator> ().enabled = true;
			anim.SetInteger ("Anim", -1);
		} else if (estado == Estado.Nada) {
			anim.GetComponent<Animator> ().enabled = false;
		}else if (estado == Estado.Andar) {
			anim.GetComponent<Animator> ().enabled = true;
			anim.SetInteger ("Anim", 1);
		} else if (estado == Estado.Vigiar) {
			anim.GetComponent<Animator> ().enabled = true;
			anim.SetInteger ("Anim", 0);
		} else if (estado == Estado.Idle) {
			anim.GetComponent<Animator> ().enabled = true;
			anim.SetInteger ("Anim", 0);
		} else if (estado == Estado.Fora) {
			anim.GetComponent<Animator> ().enabled = true;
			anim.SetInteger ("Anim", 2);
		}
	}
}

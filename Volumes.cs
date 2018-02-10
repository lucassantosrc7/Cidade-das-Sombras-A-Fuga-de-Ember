using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumes : MonoBehaviour {

	public enum Tipo
	{
		efeito,
		som
	}
	public Tipo qual_e = Tipo.efeito;

	private Slider slide;

	void Start () {
		slide = GetComponent<Slider> ();
	}

	void Update () {
		
		if (qual_e == Tipo.efeito) {
			Global.volEfeitos = slide.value;
		} if (qual_e == Tipo.som) {
			Global.volSom = slide.value;
		}
	}
}

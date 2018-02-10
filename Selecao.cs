using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecao : MonoBehaviour {

	private Text texto;
	private AudioSource source;
	public AudioClip som;

	void Start () {
		texto = GetComponent<Text> ();
		source = GetComponent<AudioSource> ();
	}

	void Update () {
		
	}

	public void Selecionou(){
		source.PlayOneShot (som, 0.3f);
		texto.fontSize = 27;
		texto.color = new Color32 (242, 171, 0, 255);
	}
	public void Deselecionou(){
		texto.fontSize = 25;
		texto.color = new Color32 (152, 107, 0, 255);
	}
	public void Clicou(){
		texto.fontSize = 25;
		texto.color = new Color32 (152, 107, 0, 255);
	}

	public void VoltarSelecionou(){
		source.PlayOneShot (som,0.3f);
		texto.fontSize = 25;
		texto.color = new Color32 (242, 171, 0, 255);
	}
	public void VoltarDeselecionou(){
		texto.fontSize = 23;
		texto.color = new Color32 (152, 107, 0, 255);
	}
	public void VoltarClicou(){
		texto.fontSize = 23;
		texto.color = new Color32 (152, 107, 0, 255);
	}
}

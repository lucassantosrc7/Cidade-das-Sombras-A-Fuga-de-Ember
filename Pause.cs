using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public GameObject menu_Pausa;
	public GameObject HUD;
	public GameObject sair;
	public GameObject opcoes;
	public GameObject controles;
	public GameObject audioVideo;

	public AudioClip somClick;
	private AudioSource source;

	void Start(){
		source = GetComponent<AudioSource> ();
		sair.SetActive (false);
	}

	public void Jogar(){
		HUD.SetActive (true);
		menu_Pausa.SetActive (false);
		Time.timeScale = 1;
		source.PlayOneShot (somClick);
	} 
	public void menu(){
		SceneManager.LoadScene ("Menu");
		Time.timeScale = 1;
		Menu.chamar = Menu.Chamar.menu;
		source.PlayOneShot (somClick);
	}

	public void Opcoes(){
		menu_Pausa.SetActive (false);
		opcoes.SetActive (true);
		source.PlayOneShot (somClick);
	}
	public void Controles(){
		opcoes.SetActive (false);
		controles.SetActive (true);
		source.PlayOneShot (somClick);
	}
	public void AudioVideo(){
		opcoes.SetActive (false);
		audioVideo.SetActive (true);
		source.PlayOneShot (somClick);
	}
	public void VoltarMenu(){
		menu_Pausa.SetActive (true);
		opcoes.SetActive (false);
		source.PlayOneShot (somClick);
	}
	public void VoltarOpcoes(){
		opcoes.SetActive (true);
		audioVideo.SetActive (false);
		controles.SetActive (false);
		source.PlayOneShot (somClick);
	}

	public void Sair(){
		sair.SetActive (true);
		source.PlayOneShot (somClick);
	}
	public void Sim(){
		Application.Quit ();
		source.PlayOneShot (somClick);
	}
	public void Nao(){
		sair.SetActive (false);
		source.PlayOneShot (somClick);
	}
}

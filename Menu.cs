using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	#region Menu
	public GameObject menu;
	public GameObject opcoes;
	public GameObject extras;
	public GameObject temCTZ;
	#endregion

	[Space(20)]
	#region Opcoes
	public GameObject controles;
	public GameObject audioVideo;
	#endregion

	[Space(20)]
	#region Extras
	public GameObject creditos;
	public GameObject concepts;
	public GameObject cutscene;
	#endregion

	private AudioSource source;
	public AudioClip somClick;

	public enum Screens{
		Menu, Opcoes, Extras, Controles, AudioVideo, Creditos, Concepts, Cutscene
	}

	public enum Chamar{
		opcoes, extras, menu
	}
	public static  Chamar chamar = Chamar.menu;

	private Screens actualScreen;
	private Screens lastScreen;

	void Start(){
		source = GetComponent<AudioSource> ();
		menu.SetActive(false);
			opcoes.SetActive(false);
				controles.SetActive(false);
			audioVideo.SetActive(false);
			extras.SetActive(false);
				creditos.SetActive (false);
				concepts.SetActive (false);
				cutscene.SetActive (false);

		if (chamar == Chamar.menu) {
			ChangeScreen (Screens.Menu);
		} else if (chamar == Chamar.extras) { 
			ChangeScreen (Screens.Extras);
		} else if (chamar == Chamar.opcoes) { 
			ChangeScreen (Screens.Opcoes);
		}
	}

	public void ChangeScreen(Screens newScreen){

		switch(lastScreen)
		{
			case Screens.Menu: 
				menu.SetActive(false);
				break;
			case Screens.Opcoes: 
				opcoes.SetActive(false);
				break;
			case Screens.Extras: 
				extras.SetActive(false);
				break;


			case Screens.Controles: 
				controles.SetActive(false);
				break;
			case Screens.AudioVideo: 
				audioVideo.SetActive(false);
				break;

			case Screens.Creditos: 
				creditos.SetActive(false);
				break;
			case Screens.Concepts: 
				concepts.SetActive(false);
				break;
			case Screens.Cutscene: 
				cutscene.SetActive(false);
				break;
		}

		switch(newScreen)
		{
			case Screens.Menu: 
				menu.SetActive(true);
				break;
			case Screens.Opcoes: 
				opcoes.SetActive(true);
				break;
			case Screens.Extras: 
				extras.SetActive(true);
				break;


			case Screens.Controles: 
				controles.SetActive(true);
				break;
			case Screens.AudioVideo: 
				audioVideo.SetActive(true);
				break;

			case Screens.Creditos: 
				creditos.SetActive(true);
				break;
			case Screens.Concepts: 
				concepts.SetActive(true);
				break;
			case Screens.Cutscene: 
				cutscene.SetActive(true);
				break;
		}

		lastScreen = newScreen;
	}

	#region MenuFuncao
	public void Jogar(){
		SceneManager.LoadScene ("cena01");
	}
	public void Opcoes(){
		ChangeScreen(Screens.Opcoes);
		source.PlayOneShot (somClick);
	}

	public void Extras(){
		ChangeScreen(Screens.Extras);
		source.PlayOneShot (somClick);
	}
	public void Sair(){
		temCTZ.SetActive (true);
		source.PlayOneShot (somClick);
	}
	#endregion

	#region MenssagemFuncao
	public void Sim(){
		Application.Quit ();
		source.PlayOneShot (somClick);
	}
	public void Nao(){
		temCTZ.SetActive (false);
		source.PlayOneShot (somClick);
	}
	#endregion

	#region OpcoesFuncao
	public void Controles(){
		ChangeScreen(Screens.Controles);
		source.PlayOneShot (somClick);
	}
	public void Audio(){
		ChangeScreen(Screens.AudioVideo);
		source.PlayOneShot (somClick);
	}
	#endregion

	#region ExtrasFuncao
	public void Creditos(){
		ChangeScreen(Screens.Creditos);
		source.PlayOneShot (somClick);
	}
	public void Concepts(){
		ChangeScreen(Screens.Concepts);
		source.PlayOneShot (somClick);
	}
	public void Cutscene(){
		ChangeScreen(Screens.Cutscene);
		source.PlayOneShot (somClick);
	}
	public void Galeria(){
		SceneManager.LoadScene ("Galeria");
		source.PlayOneShot (somClick);
	}
	#endregion

	#region VoltarFuncao
	public void Voltar(){
		ChangeScreen (Screens.Menu);
		source.PlayOneShot (somClick);
	}
	public void VoltarOpcoes(){
		ChangeScreen(Screens.Opcoes);
		source.PlayOneShot (somClick);
	}
	public void VoltarExtra(){
		ChangeScreen(Screens.Extras);
		source.PlayOneShot (somClick);
	}
	#endregion
}



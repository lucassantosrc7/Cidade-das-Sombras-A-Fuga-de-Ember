using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

[RequireComponent(typeof(AudioSource))]
public class Videos : MonoBehaviour {

	public MovieTexture movie;
	private AudioSource som;
	public GameObject play;
	public GameObject ControlMenu;

	void Start () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		som = GetComponent<AudioSource> ();
		som.clip = movie.audioClip;
	}

	void Update () {
		
		if (Input.GetMouseButtonDown(0) && movie.isPlaying) {
			movie.Pause ();
			play.gameObject.SetActive (true);
			ControlMenu.GetComponent<AudioSource> ().Play ();
		}
	}
	public void Pray(){
		movie.Play ();
		play.gameObject.SetActive (false);
		ControlMenu.GetComponent<AudioSource> ().Pause ();
	}
}

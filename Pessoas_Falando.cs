using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pessoas_Falando : MonoBehaviour {

	private AudioSource source;
	public AudioClip [] clip;
	private AudioClip som;

	void Start () {
		source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Player")) {
			som = clip [Random.Range (0, clip.Length)];
			if (!source.isPlaying) {
				source.PlayOneShot (som, Global.volSom);
			}
		}
	}
}

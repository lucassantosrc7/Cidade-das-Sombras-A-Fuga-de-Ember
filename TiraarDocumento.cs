using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraarDocumento : MonoBehaviour
{

	public GameObject texto;
	public GameObject game;
	private AudioSource source;
	
    void Start()
    {
		source = game.GetComponent<AudioSource> ();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
			source.enabled = true;
			texto.SetActive (false);
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Cutscene : MonoBehaviour
{
    public GameObject doc;

    public MovieTexture movie;
    private AudioSource som;
    public GameObject Canvas;

    void Start()
    {
        doc.GetComponent<TiraarDocumento>().enabled = false;
        GetComponent<RawImage>().texture = movie as MovieTexture;
        som = GetComponent<AudioSource>();
        som.clip = movie.audioClip;
        som.Play();
        movie.Play();
        Canvas.GetComponent<AudioSource>().Pause();
        Time.timeScale = 0;
    }

    void Update()
    {
        if (!movie.isPlaying)
        {
            doc.GetComponent<TiraarDocumento>().enabled = true;
            gameObject.SetActive(false);
            Canvas.GetComponent<AudioSource>().Play();
        }
    }
}

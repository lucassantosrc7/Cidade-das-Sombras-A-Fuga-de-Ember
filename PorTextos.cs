using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PorTextos : MonoBehaviour
{

    public enum Tipo
    {
        AnotacaoAbrir,
        Anotacao,
        AnotacaoFechar,
        legenda,
        legendaAbrir,
        Depois_do_Pipe
    }

    public Tipo tipo = Tipo.legenda;
    public GameObject texto;
    public GameObject proximo;
    [Space(20)]
    public string[] mensagem;
    public float[] Tempo_De_Falar;
    private int i = 0;
    private float tempo;
    [Space(20)]
    public bool podeIr;
    public bool Fechardepois;
    [Space(20)]
    public GameObject Quem_Fala;
    public AudioClip fala;
    private AudioSource source;

    void Start()
    {
        if (Quem_Fala != null)
        {
            source = Quem_Fala.GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (podeIr && Global.legendas)
        {
			
            if ((tipo == Tipo.legenda || tipo == Tipo.legendaAbrir) && i < mensagem.Length && Time.time > tempo)
            {
                texto.gameObject.SetActive(true);
                texto.GetComponent<Text>().text = mensagem[i];
                tempo = Time.time + Tempo_De_Falar[i];
                if (Quem_Fala != null && !Move.falando)
                {
                    source.PlayOneShot(fala);
                    Move.falando = true;
                }
                i++;
            }
            else if ((tipo == Tipo.legenda || tipo == Tipo.legendaAbrir) && i >= mensagem.Length && proximo != null && Time.time > tempo)
            {
                podeIr = false;
                texto.gameObject.SetActive(false);
                proximo.GetComponent<PorTextos>().podeIr = true;
                Move.falando = false;
            }
            else if ((tipo == Tipo.legenda || tipo == Tipo.legendaAbrir) && i >= mensagem.Length && Time.time > tempo)
            {
                podeIr = false;
                texto.gameObject.SetActive(false);
                Move.falando = false;
            }
            else if (tipo == Tipo.Anotacao && !Fechardepois)
            {
                texto.gameObject.SetActive(true);
                texto.GetComponentInChildren<Text>().text = mensagem[i];
                podeIr = false;
            }
            else if (tipo == Tipo.Anotacao && Fechardepois)
            {
                texto.gameObject.SetActive(true);
                texto.GetComponentInChildren<Text>().text = mensagem[i];
                podeIr = false;
                tipo = Tipo.AnotacaoFechar;
            }
        }
		
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("Player") && tipo == Tipo.Depois_do_Pipe)
        {
            texto.gameObject.SetActive(true);
        }
        if (hit.CompareTag("Player") && tipo == Tipo.Depois_do_Pipe && Input.GetKeyDown(KeyCode.E))
        {
            podeIr = false;
            texto.gameObject.SetActive(false);
            GetComponent<BoxCollider>().enabled = false;
            if (proximo != null)
            {
                proximo.GetComponent<PorTextos>().podeIr = true;
            }
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player") && tipo == Tipo.Depois_do_Pipe)
        {
            texto.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player") && tipo == Tipo.legendaAbrir)
        {
            podeIr = true;
        }
        else if (hit.CompareTag("Player") && tipo == Tipo.AnotacaoAbrir && Global.legendas)
        {
            texto.gameObject.SetActive(true);
            texto.GetComponentInChildren<Text>().text = mensagem[i];
            if (Fechardepois)
            {
                tipo = Tipo.AnotacaoFechar;
            }
        }
        else if (hit.CompareTag("Player") && tipo == Tipo.AnotacaoFechar)
        {
            podeIr = false;
            texto.gameObject.SetActive(false);
        }
    }
}

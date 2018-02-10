using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bueiro : MonoBehaviour
{

    private GameObject player;
    public GameObject controlMenu;

    #region Bueiro

    public enum FadeEstado
    {
        zero,
        FadeIn,
        FadeOut,
        Trocar,
        Nada

    }

    public FadeEstado estado = FadeEstado.zero;
    public Text texto;

    //variaveis para o fade
    private float tempo_Do_Fade = 10;
    private float fade;
    private float tempo;
    private float cor;
    public Image branco;

    #endregion

    void Start()
    {
        //texto.gameObject.SetActive (false);
        fade = (255 * 0.1f) / (tempo_Do_Fade / 2);
        if (estado == FadeEstado.FadeOut)
        {
            cor = 255;
        }
    }


    void Update()
    {

        if (estado == FadeEstado.FadeIn)
        {
            FadeIn();
        }
        else if (estado == FadeEstado.FadeOut)
        {
            FadeOut();
        }
        else if (estado == FadeEstado.Trocar)
        {
            controlMenu.GetComponent<TelaDeLoad>().ChangeScene("cena02");
            estado = FadeEstado.Nada;
			player.GetComponent<Collider>().GetComponent<Move>().terceira = false;
        }
    }

		
    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
			player = hit.gameObject;
            texto.gameObject.SetActive(true);
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
			player = hit.gameObject;
            branco.gameObject.SetActive(true);
            estado = FadeEstado.FadeIn;
            tempo = Time.time + 0.1f;
            texto.gameObject.SetActive(false);
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
			player = hit.gameObject;
            texto.gameObject.SetActive(false);
        }
    }

    void FadeIn()
    {
        tempo = Time.time + 0.1f;
        cor += fade;
        branco.color = new Color32(0, 0, 0, (byte)cor);
        if (cor >= 255)
        {
            estado = FadeEstado.Trocar;
        }
    }

    void FadeOut()
    {
        tempo = Time.time + 0.1f;
        cor -= fade;
        branco.color = new Color32(0, 0, 0, (byte)cor);

        if (cor <= 0)
        {
            estado = FadeEstado.zero;
        }
    }
}

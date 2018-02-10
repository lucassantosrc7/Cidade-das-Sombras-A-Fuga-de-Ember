using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ComecarPuzzle : MonoBehaviour
{

    private GameObject player;
    public Camera cam;
    public GameObject text;
    public string[] mensagem;
    private bool comecar = false;
	private bool apertou = false;

    //Receber Canvas
    public GameObject[] objs_Canvas;
    [HideInInspector]public bool venceu = false;

    //Gambiarra
    private float tempo;
    public static int num;

    void Start()
    {
        cam.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            if (venceu)
            {
                text.SetActive(true);
                text.GetComponent<Text>().text = mensagem[1];
                tempo = Time.time + 0.1f;
                venceu = false;
            }
            if (comecar)
            {
                for (int i = 0; i < objs_Canvas.Length; i++)
                {
                    objs_Canvas[i].SetActive(false);
                }
                player.GetComponent<Move>().SeMecher = false;
                cam.gameObject.SetActive(true);
            }
            else if (cam.gameObject.activeInHierarchy == true && Time.time > tempo && (text.GetComponent<Text>().text == mensagem[1] || text.GetComponent<Text>().text == mensagem[0]))
            {
                venceu = false;
                text.SetActive(false);
                cam.gameObject.SetActive(false);
                player.GetComponent<Move>().SeMecher = true;
                for (int i = 1; i < objs_Canvas.Length; i++)
                {
                    objs_Canvas[i].SetActive(true);
                }
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = mensagem[0];
            player = hit.gameObject;
        }
    }

    void OnTriggerStay(Collider hit)
    {
		if (hit.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && !apertou)
        {
            comecar = !comecar;
			apertou = true;
            text.SetActive(false);
		}else if (hit.CompareTag("Player") && Input.GetKeyUp(KeyCode.E) && apertou)
		{
			apertou = false;
		}

    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}

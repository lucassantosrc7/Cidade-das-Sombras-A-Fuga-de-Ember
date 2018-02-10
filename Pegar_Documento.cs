using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pegar_Documento : MonoBehaviour
{

    public Text texto;
    public Sprite imagem;
    public GameObject I_Canvas;

    private bool ligar = false;
    private bool apertar = false;
    private float tempo;

	public bool sol = false;
	public GameObject anotacao;


    void Awake()
    {
        
    }


    void Update()
    {
        if (I_Canvas.activeInHierarchy && Input.GetKey(KeyCode.E) && apertar && !ligar)
        {
            I_Canvas.SetActive(false);
            texto.gameObject.SetActive(false);
            Time.timeScale = 1;
            apertar = false;
            ligar = true;
			if (sol) {
				anotacao.SetActive (false);
			}
        }
        if (Input.GetKeyUp(KeyCode.E) && ligar)
        {
            ligar = false;
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            texto.gameObject.SetActive(true);
            texto.text = "Aperte E";
            if (Input.GetKeyDown(KeyCode.E) && !apertar && !ligar)
            {
                Time.timeScale = 0;
                I_Canvas.SetActive(true);
                I_Canvas.GetComponent<Image>().sprite = imagem;
                apertar = true;
                ligar = true;
            }
            if (Input.GetKeyUp(KeyCode.E) && ligar)
            {
                ligar = false;
            }
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            texto.gameObject.SetActive(false);
            texto.text = "Aperte E";
            I_Canvas.SetActive(false);
            apertar = false;
        }
    }
}

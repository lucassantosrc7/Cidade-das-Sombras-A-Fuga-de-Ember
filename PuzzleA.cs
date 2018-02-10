using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleA : MonoBehaviour
{

    public Camera cam;

    public bool selecionou;
    public int num = 10;
    private float rotacao;

    public GameObject Botao1;
    public GameObject Botao2;

    public float numCerto;
    private int numAtual = 0;
    public bool acertou;

    void Start()
    {
        rotacao = 360 / num;
    }

    void Update()
    {
		
        if (cam.gameObject.activeInHierarchy == true)
        {
            if (selecionou)
            {
                GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 255);

                if (Input.GetKeyDown(KeyCode.W))
                {
                    transform.Rotate(new Vector3(rotacao, 0, 0));
                    if (numAtual > 0)
                    {
                        numAtual--;
                    }
                    else
                    {
                        numAtual = num - 1;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.Rotate(new Vector3(-rotacao, 0, 0));
                    if (numAtual < num - 1)
                    {
                        numAtual++;
                    }
                    else
                    {
                        numAtual = 0;
                    }
                }
            }
            else
            {
                GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
            }

            if (numCerto == numAtual)
            {
                acertou = true;
            }
            else
            {
                acertou = false;
            }

        } 
			
    }

    void OnMouseDown()
    {
        selecionou = !selecionou;
        Botao1.GetComponent<PuzzleA>().selecionou = false;
        Botao2.GetComponent<PuzzleA>().selecionou = false;
    }
}

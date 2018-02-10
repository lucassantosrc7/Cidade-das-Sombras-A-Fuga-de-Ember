using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoLoris : MonoBehaviour
{

    public float speed;
    public GameObject loris;

    void Start()
    {
		
    }

    void Update()
    {
        if (loris.GetComponent<Move>().SeMecher)
        {
            if (Input.GetKey(TrocarBotao.Keys["Frente"]) && Input.GetKey(TrocarBotao.Keys["Direita"]))
            {
                transform.localEulerAngles = new Vector3(0, 45, 0);
            }
            else if (Input.GetKey(TrocarBotao.Keys["Frente"]) && Input.GetKey(TrocarBotao.Keys["Esquerda"]))
            {
                transform.localEulerAngles = new Vector3(0, 315, 0);
            }
            else if (Input.GetKey(TrocarBotao.Keys["Voltar"]) && Input.GetKey(TrocarBotao.Keys["Direita"]))
            {
                transform.localEulerAngles = new Vector3(0, 135, 0);
            }
            else if (Input.GetKey(TrocarBotao.Keys["Voltar"]) && Input.GetKey(TrocarBotao.Keys["Esquerda"]))
            {
                transform.localEulerAngles = new Vector3(0, 225, 0);
            }
            //print(transform.localEulerAngles);
            else if (Input.GetKey(TrocarBotao.Keys["Frente"]))
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetKey(TrocarBotao.Keys["Voltar"]))
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }

            if (Input.GetKey(TrocarBotao.Keys["Esquerda"]))
            {
                transform.localEulerAngles = new Vector3(0, -90, 0);
            }
            else if (Input.GetKey(TrocarBotao.Keys["Direita"]))
            {
                transform.localEulerAngles = new Vector3(0, 90, 0);
            }
        }
    }
}

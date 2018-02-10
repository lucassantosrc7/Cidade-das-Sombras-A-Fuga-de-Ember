using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarGuarda : MonoBehaviour
{

    public enum Chave
    {
        Player_ativar,
        Player_destivar,
        Encanador_ativar,
        Encanador_destivar
    }

    public Chave funcao = Chave.Player_ativar;
    public GameObject[] guarda;
	private float tempo;
	public float tempo_Comecar;
	public bool destruir_depois;
    public bool inverter_Funcao;

	private bool player;
	private bool encanador;

    void Awake()
    {
		player = false;
		encanador = false;

        if (inverter_Funcao)
        {
            if (funcao == Chave.Player_ativar)
            {
                for (int i = 0; i < guarda.Length; i++)
                {
                    guarda[i].GetComponent<PathFindingWayPoints>().enabled = false;
                }
            }
            else if (funcao == Chave.Player_destivar)
            {
                for (int i = 0; i < guarda.Length; i++)
                {
                    guarda[i].GetComponent<PathFindingWayPoints>().enabled = true;
                    guarda[i].GetComponent<PathFindingWayPoints>().tempo = Time.time + Random.Range(1, 2);
                }
            }
            else if (funcao == Chave.Encanador_ativar)
            {
                for (int i = 0; i < guarda.Length; i++)
                {
                    guarda[i].GetComponent<PathFindingWayPoints>().enabled = false;
                }
            }
            else if (funcao == Chave.Encanador_destivar)
            {
                for (int i = 0; i < guarda.Length; i++)
                {
                    guarda[i].GetComponent<PathFindingWayPoints>().enabled = true;
                    guarda[i].GetComponent<PathFindingWayPoints>().tempo = Time.time + Random.Range(5, 25);
                }
            }
        }
    }

    void Update()
    {
		if (player && funcao == Chave.Player_ativar && Time.time >= tempo && tempo!= 0)
		{
			for (int i = 0; i < guarda.Length; i++) {
				guarda [i].GetComponent<PathFindingWayPoints> ().enabled = true;
				guarda [i].GetComponentInChildren<Encanadores_Anim> ().estado = Encanadores_Anim.Estado.Andar;
			}
			if (destruir_depois) {
				Destroy (gameObject);
			}
			player = false;
		}
		else if (player && funcao == Chave.Player_destivar && Time.time >= tempo  && tempo!= 0)
		{
			for (int i = 0; i < guarda.Length; i++) {
				guarda [i].GetComponent<PathFindingWayPoints> ().enabled = false;
				guarda [i].GetComponentInChildren<Encanadores_Anim> ().estado = Encanadores_Anim.Estado.Vigiar;
				guarda [i].GetComponent<AudioSource> ().Stop ();
			}
			if (destruir_depois) {
				Destroy (gameObject);
			}
			player = false;
		}
		else if (encanador && funcao == Chave.Encanador_ativar && Time.time >= tempo  && tempo!= 0)
		{
			for (int i = 0; i < guarda.Length; i++) {
				guarda [i].GetComponent<PathFindingWayPoints> ().enabled = true;
				guarda [i].GetComponentInChildren<Encanadores_Anim> ().estado = Encanadores_Anim.Estado.Andar;
			}
			if (destruir_depois) {
				Destroy (gameObject);
			}
			encanador = false;
		}
		else if (encanador && funcao == Chave.Encanador_destivar && Time.time >= tempo  && tempo!= 0)
		{
			for (int i = 0; i < guarda.Length; i++) {
				guarda [i].GetComponent<PathFindingWayPoints> ().enabled = false;
				guarda [i].GetComponentInChildren<Encanadores_Anim> ().estado = Encanadores_Anim.Estado.Vigiar;
				guarda [i].GetComponent<AudioSource> ().Stop ();
			}
			if (destruir_depois) {
				Destroy (gameObject);
			}
			encanador = false;
		}

    }
	void OnTriggerEnter(Collider hit)
	{
		if (hit.CompareTag("Player"))
		{
			player = true;
			tempo = Time.time + tempo_Comecar;
			tempo_Comecar = 0;
		}else if (hit.CompareTag("EncanadorMestre"))
		{
			encanador = true;
			tempo = Time.time + tempo_Comecar;
			tempo_Comecar = 0;
		}
	}
}

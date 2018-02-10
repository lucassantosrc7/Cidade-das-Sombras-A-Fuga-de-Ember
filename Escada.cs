using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escada : MonoBehaviour
{

    public enum Tipo
    {
        Sobe,
        Desce,
    }

    public Tipo nome;
    public static bool estaSubindo = false;
    public static bool estaDescendo = false;
    public static bool comecarAnimacao = false;
    public static GameObject player;
    public static Vector3 posPlayer;
    public static GameObject vagalume;
    public AudioClip som;

    void Start()
    {
		
    }

    void Update()
    {


        if (comecarAnimacao)
        {
            VirarParaDescer();
        }

        if (Input.GetKey(KeyCode.W) && (estaSubindo || estaDescendo))
        {
            player.transform.Translate(Vector3.up * Move.speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && (estaSubindo || estaDescendo))
        {
            player.transform.Translate(Vector3.down * Move.speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider hit)
    {

        //SOBE
        if (hit.CompareTag("Player") && nome == Tipo.Sobe && !estaSubindo && Vagalume.pegouVagalume)
        {
            player = hit.gameObject;
            player.GetComponent<Move>().SeMecher = false;
			player.transform.eulerAngles = new Vector3 (0, player.transform.eulerAngles.y, 0);
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            estaSubindo = true;
            if (vagalume != null)
            {
                vagalume.transform.SetParent(player.transform);

            }
        }
        else if (hit.CompareTag("Player") && nome == Tipo.Sobe && !estaSubindo && !Vagalume.pegouVagalume)
        {
            Vagalume.subidaMensagem = "- Ahm, quer saber… Você vai me ajudar nessa escuridão!";
            hit.GetComponent<AudioSource>().PlayOneShot(som, Global.volSom);
        }
        else if (hit.CompareTag("Player") && nome == Tipo.Sobe && estaSubindo)
        {
            player = hit.gameObject;
            player.GetComponent<Move>().SeMecher = true;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
            estaSubindo = false;
            if (vagalume != null)
            {
                vagalume.transform.parent = null;
            }
        }

        //DESCE
        if (hit.CompareTag("Player") && nome == Tipo.Desce && !estaDescendo)
        {
            player = hit.gameObject;
            player.GetComponent<Move>().SeMecher = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            posPlayer = player.transform.position;
            comecarAnimacao = true;
            if (vagalume != null)
            {
                vagalume.transform.SetParent(player.transform);
            }
        }
        else if (hit.CompareTag("Player") && nome == Tipo.Desce && estaDescendo)
        {
            player = hit.gameObject;
            player.GetComponent<Move>().SeMecher = true;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
            estaDescendo = false;
            if (vagalume != null)
            {
                vagalume.transform.parent = null;
            }
        }

    }

    void VirarParaDescer()
    {
        if (player.transform.eulerAngles.y < -5)
        {
            player.transform.Rotate(new Vector3(0, 5, 0));
        }
        else if (player.transform.eulerAngles.y > 5)
        {
            player.transform.Rotate(new Vector3(0, -5, 0));
        }
        else if (player.transform.position.y > posPlayer.y - 1)
        {
            player.transform.Translate(Vector3.down * 2 * Time.deltaTime);
        }
        else
        {
            estaDescendo = true;
            comecarAnimacao = false;
        }
    }
}

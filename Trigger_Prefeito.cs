using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_Prefeito : MonoBehaviour
{

    private bool andar;
    private GameObject player;

    public GameObject cam;
    public GameObject legenda;
    public GameObject ultimoTexto;
    private int brigar = 0;

    void Start()
    {
		
    }

    void Update()
    {

        if (andar)
        {
            player.transform.Translate(Vector3.forward * Time.deltaTime * Move.speed);
			legenda.GetComponent<PorTextos>().podeIr = true;
        }
        else if (!andar)
        {
            andar = false;
        }

        if (ultimoTexto.GetComponent<PorTextos>().podeIr == true)
        {
            brigar = 1;
        }
        else if (ultimoTexto.GetComponent<PorTextos>().podeIr == false && brigar == 1)
        {
            RaycastPrefeito.podeIr = true;
            Move.anim.SetBool("Lutando", true);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            andar = true;
            player = hit.gameObject;
            player.GetComponent<Move>().SeMecher = false;
			player.GetComponent<AudioSource> ().Stop ();
            Move.anim.SetInteger("Anim", 1);
            hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, transform.position.z);
            hit.transform.eulerAngles = new Vector3(0, -90, 0);
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            andar = false;
            player = hit.gameObject;
            Move.anim.SetInteger("Anim", 0);
            //Mudar de Camera
            player.GetComponent<Move>().SeMecher = false;
            cam.gameObject.SetActive(true);
        }
    }
}

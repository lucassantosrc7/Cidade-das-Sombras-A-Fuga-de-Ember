using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour
{

    //Vector 3 para usar como mira para o raycast do centro
    private Vector3 VraycastC;
    public GameObject olharC;

    //Vector 3 para usar como mira para o raycast da direita
    private Vector3 VraycastD;
    public GameObject olharD;

    //Vector 3 para usar como mira para o raycast da esquerda
    private Vector3 VraycastE;
    public GameObject olharE;

    public float valor_Raycast;
    public GameObject animacao;
    [HideInInspector]public GameObject pai;
	private GameObject player;

	public static bool encanador = true;

	private AudioSource source;
	private AudioSource sourcepai;
	private AudioClip fala;
	private bool falou = false;

    void Start()
    {
		
    }

    void FixedUpdate()
    {
		if (source == null && pai != null) {
			source = GetComponent<AudioSource> ();
			sourcepai = pai.GetComponent<AudioSource> ();
			fala = pai.GetComponent<PathFindingWayPoints> ().clip [0];
		}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            encanador = false;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            encanador = true;
        }

        if (encanador)
        {
            RaycastCentro();
            RaycastDireita();
            RaycastEsquerda();
        }
    }

    void RaycastCentro()
    {
		
        VraycastC.x = olharC.transform.position.x - transform.position.x;
        VraycastC.y = olharC.transform.position.y - transform.position.y;
        VraycastC.z = olharC.transform.position.z - transform.position.z;

        Ray ray = new Ray(transform.position, VraycastC);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, valor_Raycast))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
				player = hit.collider.gameObject;
				if (pai != null)
				{
					pai.GetComponent<PathFindingWayPoints>().enabled = false;
					sourcepai.Stop ();
				}
                StartCoroutine(desativar());
				Falar ();
				player.GetComponent<Collider>().GetComponent<Move>().SeMecher = false;
				player.GetComponent<AudioSource> ().Stop();
				player.transform.LookAt(transform);
                animacao.GetComponent<Encanadores_Anim>().estado = Encanadores_Anim.Estado.Fora;
            }
        }
    }

    void RaycastDireita()
    {

        VraycastD.x = olharD.transform.position.x - transform.position.x;
        VraycastD.y = olharD.transform.position.y - transform.position.y;
        VraycastD.z = olharD.transform.position.z - transform.position.z;

        Ray ray = new Ray(transform.position, VraycastD);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, valor_Raycast))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
				player = hit.collider.gameObject;
                StartCoroutine(desativar());
                if (pai != null)
                {
                    pai.GetComponent<PathFindingWayPoints>().enabled = false;
					sourcepai.Stop ();
                }
				Falar ();
				player.GetComponent<Collider>().GetComponent<Move>().SeMecher = false;
				player.GetComponent<AudioSource> ().Stop();
				player.transform.LookAt(transform);
                animacao.GetComponent<Encanadores_Anim>().estado = Encanadores_Anim.Estado.Fora;
            }
        }
    }

    void RaycastEsquerda()
    {

        VraycastE.x = olharE.transform.position.x - transform.position.x;
        VraycastE.y = olharE.transform.position.y - transform.position.y;
        VraycastE.z = olharE.transform.position.z - transform.position.z;

        Ray ray = new Ray(transform.position, VraycastE);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, valor_Raycast))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
				player = hit.collider.gameObject;
                StartCoroutine(desativar());
                if (pai != null)
                {
                    pai.GetComponent<PathFindingWayPoints>().enabled = false;
					sourcepai.Stop ();
                }
				Falar ();
				player.GetComponent<Collider>().GetComponent<Move>().SeMecher = false;
				player.GetComponent<AudioSource> ().Stop();
				player.transform.LookAt(transform);
                animacao.GetComponent<Encanadores_Anim>().estado = Encanadores_Anim.Estado.Fora;
            }
        }
    }

	private void Falar(){
		if (!falou) {
			source.PlayOneShot (fala, Global.volSom);
			falou = true;
		}
	}

    IEnumerator desativar()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("cena01-Pego");
		player.GetComponent<Collider>().GetComponent<Move>().terceira = true;
		falou = true;
		sourcepai.Play ();
    }
}

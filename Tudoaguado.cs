using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tudoaguado : MonoBehaviour
{

    //Textos
    public GameObject cam;
    public Text texto;
    public GameObject imagem;
    public GameObject legenda;
    public string[] menssagem;
    [Space(10)]
    //Saber se venceu
	public static bool P1;
    public static bool P2;
    public static bool P3;
    [Space(10)]
    //Baixar a agua
	public GameObject agua;
    private bool V_P1 = true;
    private bool V_P2 = true;
    private bool V_P3 = true;
    private int desce = 0;
    private Animator agua_anim;
    public GameObject cam_Agua;

    //Limitar movimentaçao do player
    private bool travarPlayer = false;
    private GameObject player;
    [Space(10)]
    //Ativar os puzzles
	public GameObject[] puzzles_Colider;

    void Start()
    {
        cam.SetActive(false);
        cam_Agua.SetActive(false);
        agua.transform.localPosition = new Vector3(agua.transform.localPosition.x, -13, agua.transform.localPosition.z);
        agua_anim = agua.GetComponent<Animator>();
        for (int i = 0; i < puzzles_Colider.Length; i++)
        {
            if (puzzles_Colider[i].GetComponent<BoxCollider>().isTrigger == true)
            {
                puzzles_Colider[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F1))
        {
            P1 = true;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            P2 = true;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            P3 = true;
        }

        if (P1 && V_P1)
        {
            V_P1 = false;
            desce++;
            cam_Agua.SetActive(true);
            if (desce <= 2)
            {
                StartCoroutine(desativarCam());
            }
            else
            {
                StartCoroutine(desativarCam3());
            }
        }
        else if (P2 && V_P2)
        {
            V_P2 = false;
            desce++;
            cam_Agua.SetActive(true);
            if (desce <= 2)
            {
                StartCoroutine(desativarCam());
            }
            else
            {
                StartCoroutine(desativarCam3());
            }
        }
        else if (P3 && V_P3)
        {
            V_P3 = false;
            desce++;
            cam_Agua.SetActive(true);
            if (desce <= 2)
            {
                StartCoroutine(desativarCam());
            }
            else
            {
                StartCoroutine(desativarCam3());
            }
        }
        agua_anim.SetInteger("Desce", desce);

        if (travarPlayer && Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * Move.speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            player = hit.gameObject;
            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 90, player.transform.eulerAngles.z);
            player.GetComponent<Move>().SeMecher = false;
			player.GetComponent<AudioSource> ().Stop ();
            cam.SetActive(true);
            travarPlayer = false;
            texto.gameObject.SetActive(true);
            texto.text = menssagem[0];
            for (int i = 0; i < puzzles_Colider.Length; i++)
            {
                if (puzzles_Colider[i].GetComponent<BoxCollider>().isTrigger == true)
                {
                    puzzles_Colider[i].GetComponent<BoxCollider>().enabled = true;
                }
            }
            StartCoroutine(desligar());
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            player.GetComponent<Move>().SeMecher = true;
            travarPlayer = false;
        }
    }

    IEnumerator desligar()
    {
        yield return new WaitForSeconds(4.3f);
        cam.SetActive(false);
        texto.text = menssagem[1];
        imagem.SetActive(true);
        imagem.GetComponentInChildren<Text>().text = menssagem[2];
        travarPlayer = true;
        StartCoroutine(desativar());
    }

    IEnumerator desativar()
    {
        yield return new WaitForSeconds(2);
        texto.gameObject.SetActive(false);
    }

    IEnumerator desativarCam()
    {
        yield return new WaitForSeconds(1f);
        cam_Agua.SetActive(false);
    }

    IEnumerator desativarCam3()
    {
        yield return new WaitForSeconds(1.5f);
        cam_Agua.SetActive(false);
        agua.GetComponent<Animator>().enabled = false;
        legenda.GetComponent<PorTextos>().podeIr = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Tudoaguado>().enabled = false;
    }
}

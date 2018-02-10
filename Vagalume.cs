using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vagalume : MonoBehaviour
{

    //Primeira parte
    public string[] menssagem;
    public AudioClip[] som;
    public GameObject[] texto;
    public static string subidaMensagem = null;
    private bool podeApertar = false;
    private bool desligarFala1 = false;
    public static bool pegouVagalume;
    private GameObject player;
    private Rigidbody rb;

    //Andar
    public static bool melhorou;
    public static  bool andar = false;
    private bool rodar = false;
    //rodar
    [Space(20)]
    public GameObject pivot;
    public GameObject vagalume;

    void Start()
    {
        GetComponent<Animator>().enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (subidaMensagem != null)
        {
            texto[0].SetActive(true);
            texto[0].GetComponent<Text>().text = subidaMensagem;
            StartCoroutine(SubirSemMim());
        }

        if (pegouVagalume && !melhorou)
        {
            if (transform.position.y < player.transform.position.y + 0.6f && GetComponent<Animator>().enabled == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 2);
                GetComponent<Animator>().enabled = true;
            }
            else
            {
                vagalume.GetComponent<Animator>().SetBool("Voar", true);

            }
        }

        if (player != null && melhorou && andar)
        {
            Vector3 dir = player.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 8);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 2);
            rodar = false;
        }
        else if (player != null && melhorou && rodar)
        {
            pivot.transform.Rotate(Vector3.up * Time.deltaTime * 50);
        }

        if (pivot.transform.parent != null)
        {
            pivot.transform.position = player.transform.position;
            transform.SetParent(pivot.transform);
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("Player") && !desligarFala1 && !melhorou)
        {
            texto[0].SetActive(true);
            texto[0].GetComponent<Text>().text = menssagem[0];
            hit.GetComponent<AudioSource>().PlayOneShot(som[0], Global.volSom);
            hit.GetComponent<Move>().SeMecher = false;
            Move.anim.SetInteger("Anim", 0);
            StartCoroutine(primeiraFala(hit.gameObject));
            desligarFala1 = true;
        }
        else if (hit.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && podeApertar && !melhorou)
        {
            texto[2].SetActive(false);
            pegouVagalume = true;
            player = hit.gameObject;
        }
        else if (hit.CompareTag("Player") && podeApertar && texto[0].activeInHierarchy == false && texto[0].activeInHierarchy == false && !pegouVagalume && !melhorou)
        {
            texto[2].SetActive(true);
        }
        //Depois de Melhorar
        if (hit.CompareTag("Player") && melhorou && !rodar)
        {
            andar = false;
            rodar = true;
            pivot.transform.position = player.transform.position;
            transform.SetParent(pivot.transform);
        }

    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player") && !pegouVagalume)
        {
            texto[2].SetActive(false);
            texto[1].SetActive(true);
            texto[1].GetComponent<Text>().text = menssagem[1];
            hit.GetComponent<AudioSource>().PlayOneShot(som[1], Global.volSom);
            StartCoroutine(naopegou());
        }
        //Depois de Melhorar
        if (hit.CompareTag("Player") && melhorou)
        {
            andar = true;
            transform.parent = null;
        }
    }

    IEnumerator primeiraFala(GameObject player)
    {
        yield return new WaitForSeconds(2);
        texto[0].SetActive(false);
        texto[2].SetActive(true);
        texto[2].GetComponent<Text>().text = "Aperte E";
        podeApertar = true;
        player.GetComponent<Move>().SeMecher = true;
    }

    IEnumerator naopegou()
    {
        yield return new WaitForSeconds(2);
        texto[1].SetActive(false);
    }

    IEnumerator SubirSemMim()
    {
        yield return new WaitForSeconds(2);
        texto[0].SetActive(false);
        subidaMensagem = null;
    }
}

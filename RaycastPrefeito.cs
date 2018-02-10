using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AI;

public class RaycastPrefeito : MonoBehaviour
{

    public static bool podeIr;

    public GameObject barra;
    public GameObject minimap;

    //Estado é em releção ao prefeito
    private enum Estado
    {
        Patrulha,
        PatrulhaAposGolpe,
        Golpe,
        esperarGolpes,
        atacou,
        atacado
    }

    private Estado estado;
    private int vida = 3;
    private int vidaPlayer = 3;
    public GameObject[] barra_Player;
    public GameObject[] barra_Prefeito;

    [Space(10)]

    public GameObject prefeito;
    private Animator anim;


    public GameObject player;
    private bool apertou = false;
    private bool lutar;

    [Space(10)]

    #region Ataque
	public Camera cam;
    public Text texto;
    private int i = 0;
    public KeyCode[] ataque_1;
    public KeyCode[] ataque_2;
    public KeyCode[] ataque_3;
    private KeyCode botao;

    public float tempo_Para_Apertar;
    private float tempo_apertar;
    private float tempo_golpe;

    #endregion

    void Start()
    {
        anim = prefeito.GetComponent<Animator>();
        estado = Estado.Patrulha;
        texto.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if (vida <= 0)
        {
            player.transform.Translate(new Vector3(0, 0, -0.5f));
            podeIr = false;
            player.GetComponent<Move>().SeMecher = true;
            GetComponent<RaycastPrefeito>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            Move.anim.SetInteger("Luta", 0);
            Move.anim.SetBool("Lutando", false);
            Move.anim.SetInteger("Anim", 0);
            cam.gameObject.SetActive(false);
            barra.SetActive(false);
            minimap.SetActive(true);

        }
        if ((estado == Estado.Patrulha || estado == Estado.PatrulhaAposGolpe) && podeIr && !apertou)
        {
            cam.gameObject.SetActive(true);
            anim.SetBool("Lutar", true);
            Move.anim.SetInteger("Luta", 4);
            apertou = true;
            tempo_apertar = Time.time + 0.3f;
            barra.SetActive(true);
            minimap.SetActive(false);
        }
        if (apertou && Time.time > tempo_apertar)
        {
            if (estado == Estado.Patrulha && podeIr)
            {
                anim.SetInteger("Luta", 2);
                transform.LookAt(player.transform.position);
                transform.Translate(Vector3.forward * Time.deltaTime);
                player.transform.LookAt(transform.position);
                player.transform.Translate(Vector3.forward * Time.deltaTime * Move.speed);
            }
            else if (estado == Estado.PatrulhaAposGolpe && podeIr)
            {
                transform.LookAt(player.transform.position);
                transform.Translate(Vector3.forward * Time.deltaTime * Move.speed);
            }
        }
        if (vidaPlayer == 2)
        {
            barra_Player[2].SetActive(false);
        }
        else if (vidaPlayer == 1)
        {
            barra_Player[1].SetActive(false);
        }
        else if (vidaPlayer <= 0)
        {
            barra_Player[0].SetActive(false);
        }

        if (vida == 2)
        {
            barra_Prefeito[2].SetActive(false);
        }
        else if (vida == 1)
        {
            barra_Prefeito[1].SetActive(false);
        }
        else if (vida <= 0)
        {
            barra_Prefeito[0].SetActive(false);
        }

    }

    #region Patrulha Funcao

    void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            if (estado == Estado.Patrulha || estado == Estado.PatrulhaAposGolpe)
            {
                estado = Estado.Golpe;
                Move.anim.SetInteger("Luta", 0);
                anim.SetInteger("Lutando", 0);
                apertou = false;
            }

            if ((estado == Estado.Golpe || estado == Estado.esperarGolpes) && vida >= 3)
            {
                Golpes(ataque_1);
            }
            else if ((estado == Estado.Golpe || estado == Estado.esperarGolpes) && vida == 2)
            {
                Golpes(ataque_2);
            }
            else if ((estado == Estado.Golpe || estado == Estado.esperarGolpes) && vida == 1)
            {
                Golpes(ataque_3);
            }

            if (estado == Estado.atacado)
            {
                player.transform.Translate(Vector3.back * Time.deltaTime * Move.speed);
            }
            else if (estado == Estado.atacou)
            {
                player.transform.Translate(Vector3.back * Time.deltaTime * Move.speed);
            }
        }
    }

    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            if (estado == Estado.atacado)
            {
                //transform.Translate(new Vector3(0, 0, -2));
                if (vidaPlayer > 0)
                {
                    StartCoroutine(Cair(0.11f));
                }
                else
                {
                    StartCoroutine(CairNocautePl());
                }
            }
            else if (estado == Estado.atacou)
            {
                StartCoroutine(Cair(0.11f));
            }
        }
    }

    #endregion

    #region Ataque Funcao

    void Golpes(KeyCode[] sequencia)
    {

        if (i < sequencia.Length && estado == Estado.Golpe && Time.time > tempo_golpe)
        {
            Move.anim.SetInteger("Luta", 0);
            anim.SetInteger("Lutando", 0);
            //Mudar botão
            botao = sequencia[i];
            i++;
            //Mudar Texto
            texto.gameObject.SetActive(true);
            texto.text = "Aperte " + botao.ToString();
            //Ir para o ataque
            estado = Estado.esperarGolpes;
            tempo_apertar = Time.time + tempo_Para_Apertar;
        }
        if (Input.GetKeyDown(botao) && estado == Estado.esperarGolpes)
        {
            texto.gameObject.SetActive(false);
            Move.anim.SetInteger("Luta", 1);
            if (vida > 0)
            {
                anim.SetInteger("Lutando", 3);
            }
            else
            {
                anim.SetInteger("Lutando", 4);
            }
            
            tempo_golpe = Time.time + 1.5f;
            if (i < sequencia.Length)
            {
                estado = Estado.Golpe;
            }
            else
            {
                vida--;
                i = 0;
                estado = Estado.atacado;
            }

        }
        else if (Time.time > tempo_apertar && estado == Estado.esperarGolpes)
        {
            texto.gameObject.SetActive(false);
            i = 0;
            estado = Estado.atacou;
            if (vidaPlayer > 1)
            {
                Move.anim.SetInteger("Luta", 2);
            }
            else
            {
                Move.anim.SetInteger("Luta", 3);
            }
            vidaPlayer--;
        }
    }

    #endregion

    #region Animação

    IEnumerator Cair(float temp)
    {
        yield return new WaitForSeconds(temp);
        estado = Estado.PatrulhaAposGolpe;
    }

    IEnumerator CairNocautePl()
    {
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene("Cena03");
    }

    IEnumerator CairNocautePF()
    {
        yield return new WaitForSeconds(1);
        podeIr = false;
        player.GetComponent<Move>().SeMecher = true;
        Move.anim.SetInteger("Luta", 0);
        Move.anim.SetInteger("Anim", 0);
        GetComponent<RaycastPrefeito>().enabled = false;

    }

    #endregion
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    private bool movendo;
    public GameObject loris;
    public static Animator anim;

    private Vector3 moveDirection;
    private float getX;
    private float getY;
    public static float speed = 4;
    private float speedIni;
    private float speedAga;
    private float speedCor;
    public bool SeMecher = true;

    public float mouseSensivity = 300;
    private float rotationY;

    //Trocar Camera Variaavei
    public bool terceira = true;
    public bool temCamera = true;
    public Camera primeiraCam;
    public Camera terceiraCam;

    private AudioSource source;
    public AudioClip somAndar;
    public static bool falando = false;

    public GameObject menu_Pausa;
    public GameObject Hud;

    void Start()
    {
        speedIni = speed;
        speedAga = speed - (speed / 2);
        speedCor = speed + (speed / 2);

        terceiraCam.gameObject.SetActive(true);
        primeiraCam.gameObject.SetActive(false);

        source = GetComponent<AudioSource>();
        if (loris != null)
        {
            anim = loris.GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("cena01");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("cena02");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("cena03");
        }

		if (SeMecher) {
			if (Input.GetKey (TrocarBotao.Keys ["Correr"])) {
				speed = speedCor;
			} else if (Input.GetKey (TrocarBotao.Keys ["Agachar"])) {
				speed = speedAga;
				if (primeiraCam.gameObject.transform.localPosition.y > 0.16f) {
					primeiraCam.gameObject.transform.Translate (Vector3.down * 0.25f);
				}
			} else {
				speed = speedIni;
				if (primeiraCam.gameObject.transform.localPosition.y < 0.545f) {
					primeiraCam.gameObject.transform.Translate (Vector3.up * 0.25f);
				}
			}

			if (Input.GetKey (TrocarBotao.Keys ["Frente"])) {
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
				if (loris != null) {
					loris.transform.localScale = new Vector3 (1, 1, 1);
				}
				//Chamar Animação
				if (speed == speedCor && loris != null) {
					anim.SetInteger ("Anim", 2);
				} else if (speed == speedAga && loris != null) {
					anim.SetInteger ("Anim", 3);
				} else if (loris != null) {
					anim.SetInteger ("Anim", 1);
				}
				//Som
				if (!source.isPlaying) {
					source.PlayOneShot (somAndar, 0.7f);
				}
			} else if (Input.GetKey (TrocarBotao.Keys ["Voltar"])) {
				transform.Translate (Vector3.back * speed * Time.deltaTime);
				if (loris != null) {
					loris.transform.localScale = new Vector3 (1, 1, -1);
				}

				//Chamar Animação
				if (speed == speedCor && loris != null) {
					anim.SetInteger ("Anim", 2);
				} else if (speed == speedAga && loris != null) {
					anim.SetInteger ("Anim", 3);
				} else if (loris != null) {
					anim.SetInteger ("Anim", 1);
				}
				//Som
				if (!source.isPlaying) {
					source.PlayOneShot (somAndar, 0.7f);
				}
			}
         

			if (Input.GetKey (TrocarBotao.Keys ["Esquerda"])) {
				transform.Translate (Vector3.left * speed / 2 * Time.deltaTime);
			} else if (Input.GetKey (TrocarBotao.Keys ["Direita"])) {
				transform.Translate (Vector3.right * speed / 2 * Time.deltaTime);
			}


			if (Input.GetKey (TrocarBotao.Keys ["Direita"]) || Input.GetKey (TrocarBotao.Keys ["Esquerda"]) ||
			    Input.GetKey (TrocarBotao.Keys ["Voltar"]) || Input.GetKey (TrocarBotao.Keys ["Frente"])) {
				movendo = true;
			} else {
				movendo = false;
				if (speed == speedAga && loris != null) {
					anim.SetInteger ("Anim", 4);
				} else if (loris != null) {
					anim.SetInteger ("Anim", 0);
				}
				if (!falando) {
					source.Stop ();
				}
			}
		}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu_Pausa.SetActive(!menu_Pausa.activeInHierarchy);
            Hud.SetActive(!Hud.activeInHierarchy);
            Time.timeScale = (Time.timeScale - 1) * -1;
        }

    }

    public void FixedUpdate()
    {
        if (temCamera && terceira == true)
        { 
            terceiraCam.gameObject.SetActive(true);
            primeiraCam.gameObject.SetActive(false);
        }
        else if (temCamera && terceira == false)
        {
            primeiraCam.gameObject.SetActive(true);
            terceiraCam.gameObject.SetActive(false);
        }
        else
        {
            primeiraCam.gameObject.SetActive(false);
            terceiraCam.gameObject.SetActive(false);
        }

        if (SeMecher)
        {
            rotateView(terceira);
        }
      
    }

    void rotateView(bool Mode)
    {

        if (!terceira)
        {
            //movimento em X do mouse
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime);

            //calcula rotacao em Y
            rotationY += Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -45, 45);

            //aplica movimento na câmera
            primeiraCam.transform.localEulerAngles = new Vector3(-rotationY, primeiraCam.transform.localEulerAngles.y, primeiraCam.transform.localEulerAngles.z);
        }
        else if (terceira)
        {
         
            //movimento em X do mouse
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime);

            //aplica movimento na câmera
            terceiraCam.transform.localEulerAngles = new Vector3(terceiraCam.transform.eulerAngles.x, terceiraCam.transform.localEulerAngles.y, terceiraCam.transform.localEulerAngles.z);
        }

    }
}
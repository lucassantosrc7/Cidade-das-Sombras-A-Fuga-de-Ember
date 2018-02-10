
using UnityEngine;
using System.Collections;


public class PathFindingWayPoints : MonoBehaviour {
	
	public  float       speed    = 5;
	public  float       rotSpeed = 10;
	public  Transform[] waypoints;
	public int [] vigia;
	private int         currentWayPoint;
	private Rigidbody   rb;

	private enum Estado { Andar, Vigia, Parado };
	private Estado estado = Estado.Andar;

	public GameObject cara;
	public GameObject animacao;

	//Som
	[HideInInspector]public AudioSource source;
	public AudioClip [] clip;
	public AudioClip andar;
	private AudioClip som;
	[HideInInspector]public float tempo;

	public void Awake() {
		currentWayPoint = 0;
		rb              = GetComponent<Rigidbody>();
		if (cara != null) {
			cara.GetComponent<Raycast> ().pai = gameObject;
		}
		source = GetComponent<AudioSource> ();
		tempo = Time.time + Random.Range (5,25);
	}

	public void FixedUpdate() {
		if (estado == Estado.Andar) {
			Vector3 dir = waypoints [currentWayPoint].position - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (dir), Time.deltaTime * rotSpeed);
			transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);

			if (Time.time > tempo) {
				tempo = Time.time + Random.Range (1, 50);
				som = clip [Random.Range (1, clip.Length)];
				source.PlayOneShot (som, Global.volSom);
				tempo = Time.time + Random.Range (5,25);
			}

			if (dir.sqrMagnitude <= 1) {
				currentWayPoint++;
				AnalisarWay ();
				if (currentWayPoint >= waypoints.Length)
					currentWayPoint = 0;
			} else {
				if (!source.isPlaying) {
					source.PlayOneShot (andar, Global.volSom);
				}
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                if (animacao != null) {
					animacao.GetComponent<Encanadores_Anim> ().estado = Encanadores_Anim.Estado.Andar;
                    animacao.GetComponent<Encanadores_Anim>().consertando = false;

                }
			}
		} else if (estado == Estado.Vigia) {
			Vigiar ();
		}
	}

	private void AnalisarWay(){
		
		for(int i = 0; i < vigia.Length; i++){
			if (vigia [i] + 1 == currentWayPoint) {
				estado = Estado.Vigia;
				i = vigia.Length;
			} else
				estado = Estado.Andar;
            animacao.GetComponent<Encanadores_Anim>().consertando = false;
        }
	}

	private void Vigiar(){
		StartCoroutine (TerminouVigia ());
		source.Stop ();
		if (animacao != null) {
			animacao.GetComponent<Encanadores_Anim> ().estado = Encanadores_Anim.Estado.Vigiar;
            animacao.GetComponent<Encanadores_Anim>().consertando = false;
        }
		if (cara != null) {
			cara.GetComponent<Animator> ().enabled = true;
		}
	}

	IEnumerator TerminouVigia()
	{
		yield return new WaitForSeconds(3);
		estado = Estado.Andar;
		if (cara != null) {
			cara.GetComponent<Animator> ().enabled = false;
		}
		if (animacao != null) {
			animacao.GetComponent<Encanadores_Anim> ().estado = Encanadores_Anim.Estado.Nada;
		}
	}

	void OnTriggerEnter(Collider hit){
		if (hit.CompareTag ("Parar")) {
			estado = Estado.Parado;
		}
	}
}

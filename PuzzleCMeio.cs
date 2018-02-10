using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCMeio : MonoBehaviour {

	public Camera cam;

	public GameObject Meio;
	private bool mecher;
	private bool saiu = false;

	void Start(){
		
	}

	void Update () {
		if (cam.gameObject.activeInHierarchy == true) {
			if (Input.GetMouseButton (0) && mecher && !saiu) {
				//rotaciona pra direção do mouse
				Vector3 mouseWorldPosition = cam.ScreenToWorldPoint (Input.mousePosition);
				Vector3 direction = new Vector3 (mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);
				Meio.transform.LookAt (direction);
			}
			if (Input.GetMouseButtonDown (0)) {
				saiu = false;
			}
		}
	}
	void OnMouseOver(){
		mecher = true;
	}
	void OnMouseExit(){
		mecher = false;
		saiu = true;
	}
}

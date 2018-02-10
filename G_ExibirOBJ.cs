using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_ExibirOBJ : MonoBehaviour {

	public bool mover = false;
	public bool img = false;

	void Update () {
		if (mover) {
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (new Vector3 (0, 1, 0));
			}
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (new Vector3 (0, -1, 0));
			}
		}
	}
}

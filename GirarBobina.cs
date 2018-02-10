using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarBobina : MonoBehaviour {

	void Update () {
		transform.Rotate (new Vector3 (-1, 0, 0));
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolucao : MonoBehaviour {

	public Dropdown drop;

	void Start () {
		
	}

	void Update () {
		if (drop.value == 0) {
			print ("sdadd");
		}
		else if (drop.value == 1) {
			print ("adffsadf");
		}
	}
}

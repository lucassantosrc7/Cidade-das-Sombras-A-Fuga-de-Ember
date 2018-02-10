using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualidadeGraficos : MonoBehaviour {

	private Dropdown drop;

	void Awake () {
		drop = GetComponent<Dropdown> ();
		drop.value = 2;
	}
	

	void Update () {

		if (drop.value == 0) {
			QualitySettings.SetQualityLevel (0);
		}
		if (drop.value == 1) {
			QualitySettings.SetQualityLevel (1);
		}
		if (drop.value == 2) {
			QualitySettings.SetQualityLevel (2);
		}
		if (drop.value == 3) {
			QualitySettings.SetQualityLevel (3);
		}
		if (drop.value == 4) {
			QualitySettings.SetQualityLevel (4);
		}
		if (drop.value == 5) {
			QualitySettings.SetQualityLevel (5);
		}
	}
}

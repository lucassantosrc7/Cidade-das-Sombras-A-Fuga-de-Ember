using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Legenda : MonoBehaviour
{
    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    void Update()
    {
        if (toggle.isOn)
        {
            Global.legendas = true;
        }
        else
        {
            Global.legendas = false;
        }
    }
}

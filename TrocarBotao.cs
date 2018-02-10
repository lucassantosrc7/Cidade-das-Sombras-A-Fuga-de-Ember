using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrocarBotao : MonoBehaviour
{

    public static Dictionary <string, KeyCode> Keys = new Dictionary<string, KeyCode>();

    public Text frente, direita, esquerda, atras, correr, agachar;
    private GameObject currentKey;

    private Color32 normal = new Color32(255, 255, 255, 255);
    private Color32 selected = new Color32(100, 100, 100, 255);

    void Start()
    {

        Keys.Add("Frente", KeyCode.W);
        Keys.Add("Direita", KeyCode.D);
        Keys.Add("Esquerda", KeyCode.A);
        Keys.Add("Voltar", KeyCode.S);
        Keys.Add("Correr", KeyCode.LeftShift);
        Keys.Add("Agachar", KeyCode.LeftControl);


        frente.text = Keys["Frente"].ToString();
        direita.text = Keys["Direita"].ToString();
        esquerda.text = Keys["Esquerda"].ToString();
        atras.text = Keys["Voltar"].ToString();
        correr.text = Keys["Correr"].ToString();
        agachar.text = Keys["Agachar"].ToString();
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                Keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }
}

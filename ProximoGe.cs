using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProximoGe : MonoBehaviour
{
    public GameObject controlMenu;
    private bool trocar = true;
	private GameObject player;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player") && trocar)
        {
            controlMenu.GetComponent<TelaDeLoad>().ChangeScene("cena03");
			player.GetComponent<Collider>().GetComponent<Move>().terceira = false;
        }
    }
}

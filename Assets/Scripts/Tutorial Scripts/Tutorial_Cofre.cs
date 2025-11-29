using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial_Cofre : MonoBehaviour
{
    public TextMeshProUGUI Cofre;

    private const string Jugador = "Player";
    void Start()
    {
        if (Cofre != null)
        {
            Cofre.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Jugador))
        {
            Mensaje(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Jugador))
        {
            Mensaje(false);
        }
    }
    private void Mensaje(bool visible)
    {

        if (Cofre != null)
        {

            Cofre.gameObject.SetActive(visible);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial_Puerta : MonoBehaviour
{
    public TextMeshProUGUI Puerta;

    private const string Jugador = "Player";
    void Start()
    {
        if (Puerta != null)
        {
            Puerta.gameObject.SetActive(false);
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
      
        if (Puerta != null)
        {
          
            Puerta.gameObject.SetActive(visible);
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}

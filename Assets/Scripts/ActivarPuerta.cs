using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPuerta : MonoBehaviour
{
    public MoverPuerta puerta;
    private bool jugadorEnArea = false;
    private bool puertaAbierta = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Debug.Log("Jugador en zona");
            jugadorEnArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        jugadorEnArea = false;
    }
    private void Update()
    {
        if(jugadorEnArea && Input.GetButtonDown("Fire2")) //La tecla es la letra "e"
        {
            if (puertaAbierta)
            {
                Debug.Log("Cerrar");
                puerta.AbrirPuerta(false);
                puertaAbierta = false;
            }
            else
            {
                Debug.Log("Abrir");
                puerta.AbrirPuerta(true);
                puertaAbierta = true;
            }
            
        }
    }
}

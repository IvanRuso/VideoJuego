using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPuerta : MonoBehaviour
{
    private bool jugadorEnArea = false;

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
    public bool ChecarJugador()
    {
        if (jugadorEnArea)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

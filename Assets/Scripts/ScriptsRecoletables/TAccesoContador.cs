using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TAccesoContador : MonoBehaviour
{
    public TextMeshProUGUI TAcceso;
    public MoverPuerta puerta;
    public ActivarPuerta activarPuerta;
    public int TAccesoJugador = 0;
    private bool jugadorEnArea = false;
    private bool puertaAbierta = false;

    private FullScreenController FullScreenController;
    // Start is called before the first frame update
    void Start()
    {
        ActualizarPantalla();
    }

    // Update is called once per frame
   
    public void ActivaPuerta()
    {
        if(TAccesoJugador == 0)
        {
            Debug.Log("No llaves");
            return;
        }

        jugadorEnArea = activarPuerta.ChecarJugador();
        if (jugadorEnArea)
        {
            if (!puertaAbierta)
            {
                /*    Debug.Log("Cerrar");
                    puerta.AbrirPuerta(false);
                    puertaAbierta = false;
                }
                else
                {*/
                Debug.Log("Abrir");
                puerta.AbrirPuerta(true);
                puertaAbierta = true;
            }
            TAccesoJugador--;
            Debug.Log("LLave Usada");
        }
        else 
        { 
            Debug.Log("No se puede usar la llave aqui"); 
        }

            ActualizarPantalla();
    }

    public void Actualiza(int Agrega)
    {
        TAccesoJugador += Agrega;
        ActualizarPantalla();
    }

    private void ActualizarPantalla()
    {
        if (TAcceso != null)
        {
            TAcceso.text = "X" + TAccesoJugador.ToString();
        }
        else
        {
            Debug.LogError("El TextMeshProUGUI no esta asignado en el Inspector.");
        }
    }
}

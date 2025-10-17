using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Escudo : MonoBehaviour
{
    public TextMeshProUGUI Escudos;
    public int CantidadEscudos = 3;

    private VidaPlayer vidaJugador;
    //private Mensaje mensajePantalla;

    void Start()
    {
        ActualizarPantalla();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            vidaJugador = playerObject.GetComponent<VidaPlayer>();
        }
        else
        {
            Debug.LogError("No se encontro un objeto con la etiqueta 'Player' que tenga el script VidaJugador");
        }

        /*GameObject playerObject2 = GameObject.FindGameObjectWithTag("mensaje");
        if (playerObject2 != null)
        {
            mensajePantalla = playerObject2.GetComponent<Mensaje>();
        }
        else
        {
            Debug.LogError("No se encontr� un objeto con la etiqueta 'mensaje' que tenga el script PlayerHealth.");
        }*/
    }

    void Update()
    {
        /*if (vidaJugador.Vida < vidaJugador.VidaMaxima && CantidadBotiquines > 0)
        {
            mensajePantalla.mensaje = "Recuperar Corazon (Presiona 1)";
        }*/


        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            UsarEscudo();
            /*if (vidaJugador.Vida == vidaJugador.VidaMaxima)
            {
                mensajePantalla.mensaje = "";
            }*/


        }
        /*else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            mensajePantalla.mensaje = "";
        }*/
    }

    private void UsarEscudo()
    {
        if (CantidadEscudos == 0)
        {
            //mensajePantalla.mensaje = "No Hay Botiquin";
            Debug.Log(" X " + CantidadEscudos);
            return;
        }

        bool Curado = vidaJugador.RecuperarEscudo(1);

        if (Curado)
        {
            CantidadEscudos--;
            ActualizarPantalla();

            Debug.Log(" X " + CantidadEscudos);
        }
    }

    private void ActualizarPantalla()
    {
        if (Escudos != null)
        {
            Escudos.text = "X " + CantidadEscudos.ToString();
        }
        else
        {
            Debug.LogError("El TextMeshProUGUI no esta asignado en el Inspector.");
        }
    }
}

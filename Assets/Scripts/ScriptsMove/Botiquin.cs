using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Botiquin : MonoBehaviour
{
    public TextMeshProUGUI Botiquines;
    public int CantidadBotiquines = 3;
    private VidaPlayer vidaJugador;
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
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            UsarBotiquin();
        }
    }
    private void UsarBotiquin()
    {
        if (CantidadBotiquines == 0)
        {
            //mensajePantalla.mensaje = "No Hay Botiquin";
            Debug.Log(" X " + CantidadBotiquines);
            return;
        }

        bool Curado = vidaJugador.RecuperarVida(1);

        if (Curado)
        {
            CantidadBotiquines--;
            ActualizarPantalla();

            Debug.Log(" X " + CantidadBotiquines);
        }
    }
    private void ActualizarPantalla()
    {
        if (Botiquines != null)
        {
            Botiquines.text = "X " + CantidadBotiquines.ToString();
        }
        else
        {
            Debug.LogError("El TextMeshProUGUI no esta asignado en el Inspector.");
        }
    }

}
//private Mensaje mensajePantalla;

/*GameObject playerObject2 = GameObject.FindGameObjectWithTag("mensaje");
if (playerObject2 != null)
{
  mensajePantalla = playerObject2.GetComponent<Mensaje>();
}
else
{
  Debug.LogError("No se encontr� un objeto con la etiqueta 'mensaje' que tenga el script PlayerHealth.");
}*/
/*if (vidaJugador.Vida < vidaJugador.VidaMaxima && CantidadBotiquines > 0)
{
    mensajePantalla.mensaje = "Recuperar Corazon (Presiona 1)";
}*/
/*if (vidaJugador.Vida == vidaJugador.VidaMaxima)
{
    mensajePantalla.mensaje = "";
}*/

/*else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
{
    mensajePantalla.mensaje = "";
}*/

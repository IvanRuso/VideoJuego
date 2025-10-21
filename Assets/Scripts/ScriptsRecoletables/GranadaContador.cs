using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;

public class GranadaContador : MonoBehaviour
{
    public TextMeshProUGUI Granadas;
    public int GranadasJugador = 0;
    // Start is called before the first frame update
    void Start()
    {
        ActualizarPantalla();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            LanzaGranada();
        }
    }

    private void LanzaGranada()
    {
        if (GranadasJugador == 0)
        {
            //mensajePantalla.mensaje = "No Hay Botiquin";
            Debug.Log(" X " + GranadasJugador);
            return;
        }

        if (GranadasJugador >= 0)
        {
            GranadasJugador--;
            ActualizarPantalla();

            Debug.Log(" X " + GranadasJugador);
        }
    }

    public void Actualiza(int Agrega=1)
    {
        GranadasJugador += Agrega;
        ActualizarPantalla();
    }
    private void ActualizarPantalla()
    {
        if (Granadas != null)
        {
            Granadas.text = "X " + GranadasJugador.ToString();
        }
        else
        {
            Debug.LogError("El TextMeshProUGUI no esta asignado en el Inspector.");
        }
    }

}

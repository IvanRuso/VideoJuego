using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class BotiquinContador : MonoBehaviour
{

    public TextMeshProUGUI Botiquines;
    public int BotiquinJugador = 0;

    private VidaPlayer CorazonesJugador;
    // Start is called before the first frame update
    void Start()
    {
        CorazonesJugador = GetComponent<VidaPlayer>();
        ActualizarPantalla();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            RecuperarVida();
        }
    }

    private void RecuperarVida()
    {
        if (BotiquinJugador == 0)
        {
            Debug.Log("No Botiquines");
            return;
        }

        bool Curado = CorazonesJugador.RecuperarVida(2);

        if (Curado)
        {
            BotiquinJugador--;
            ActualizarPantalla();;
        }
    }

    public void Actualiza(int Agrega)
    {
        BotiquinJugador += Agrega;
        ActualizarPantalla();
    }
    private void ActualizarPantalla()
    {
        if( Botiquines!= null)
        {
            Botiquines.text = "X" + BotiquinJugador.ToString();
        }
        else
        {
            Debug.LogError("No asignado");
        }
    }

}

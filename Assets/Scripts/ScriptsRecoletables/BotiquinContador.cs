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
    private FullScreenController FullScreenController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("ScreenEffect");
        if (playerObject != null)
        {
            FullScreenController = playerObject.GetComponent<FullScreenController>();
        }
        else
        {
            Debug.LogError("No se encontro un objeto con la etiqueta 'Player' que tenga el script VidaJugador");
        }

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
            ActualizarPantalla();
            StartCoroutine(FullScreenController.Status(1));
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

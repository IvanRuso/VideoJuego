using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EscudoContador : MonoBehaviour
{
    public TextMeshProUGUI Escudos;
    public int EscudosJugador = 0;

    private VidaPlayer EscudoJugador;
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

        EscudoJugador = GetComponent<VidaPlayer>();
        ActualizarPantalla();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            RecuperarEscudo();
        }
        
    }
    private void RecuperarEscudo()
    {
        if (EscudosJugador == 0)
        {
            Debug.Log(" No escudos");
            return;
        }

        bool Curado = EscudoJugador.RecuperarEscudo(1);

        if (Curado)
        {
            EscudosJugador--;
            ActualizarPantalla();
            StartCoroutine(FullScreenController.Status(2));
        }
    }

    public void Actualiza(int Agrega)
    {
        EscudosJugador += Agrega;
        ActualizarPantalla();
    }

    private void ActualizarPantalla()
    {
        if (Escudos != null)
        {
            Escudos.text = "X " + EscudosJugador.ToString();
        }
        else
        {
            Debug.LogError("El TextMeshProUGUI no esta asignado en el Inspector.");
        }
    }
}

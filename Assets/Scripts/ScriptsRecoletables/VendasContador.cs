using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendasContador : MonoBehaviour
{

    public TextMeshProUGUI Vendas;
    public int VendasJugador = 0;

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
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            RecuperarVida();
        }
    }

    private void RecuperarVida()
    {
        if (VendasJugador == 0)
        {
            Debug.Log("No Vendas");
            return;
        }

        bool Curado = CorazonesJugador.RecuperarVida(1);

        if (Curado)
        {
            VendasJugador--;
            ActualizarPantalla();
            StartCoroutine(FullScreenController.Status(1));
        }
    }

    public void Actualiza(int Agrega)
    {
        VendasJugador += Agrega;
        ActualizarPantalla();
    }
    private void ActualizarPantalla()
    {
        if (Vendas != null)
        {
            Vendas.text = "X" + VendasJugador.ToString();
        }
        else
        {
            Debug.LogError("No asignado");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VendasContador : MonoBehaviour
{

    public TextMeshProUGUI Vendas;
    public int VendasJugador = 0;

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
            ActualizarPantalla(); ;
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

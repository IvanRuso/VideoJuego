using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TAccesoContador : MonoBehaviour
{
    public TextMeshProUGUI TAcceso;
    [SerializeField] private ActivarPuerta[] puertas;
    private List<MoverPuerta> puertasAMover = new List<MoverPuerta>();
    public int tAccesoJugador = 0;
    private int sfxToPlay;
    private bool jugadorEnArea = false;
    // ELIMINAR: private bool puertaAbierta = false;

    void Start()
    {
        ActualizarPantalla();
        puertas = FindObjectsOfType<ActivarPuerta>();
    }

    public void ActivaPuerta()
    {
        if (tAccesoJugador == 0)
        {
            Debug.Log("No hay llaves");
            return;
        }

        // Limpiar listas cada vez
        puertasAMover.Clear();
        jugadorEnArea = false;

        foreach (ActivarPuerta puerta in puertas)
        {
            if (puerta.ChecarJugador())
            {
                jugadorEnArea = true;
                MoverPuerta moverPuerta = puerta.PuertaAMover();
                if (moverPuerta != null)
                {
                    puertasAMover.Add(moverPuerta);
                }
            }
        }

        if (jugadorEnArea && puertasAMover.Count > 0)
        {
            // Abrir TODAS las puertas sin verificar puertaAbierta
            foreach (MoverPuerta puerta in puertasAMover)
            {
                Debug.Log("Abriendo puerta: " + puerta.gameObject.name);
                puerta.AbrirPuerta(true);
                sfxToPlay = 23;
                AudioManager.instance.SoundEffects(sfxToPlay);
            }

            tAccesoJugador--;
            Debug.Log("Llave Usada. Puertas abiertas: " + puertasAMover.Count);
        }
        else
        {
            Debug.Log("No se puede usar la llave aqui");
        }

        ActualizarPantalla();
    }

    // ... el resto del código igual


public void Actualiza(int Agrega)
    {
        tAccesoJugador += Agrega;
        ActualizarPantalla();
    }

    private void ActualizarPantalla()
    {
        if (TAcceso != null)
        {
            TAcceso.text = "X" + tAccesoJugador.ToString();
        }
        else
        {
            Debug.LogError("El TextMeshProUGUI no esta asignado en el Inspector.");
        }
    }
}

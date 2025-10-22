using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPuerta : MonoBehaviour
{
    public float distanciaApertura = 5f;
    public float velocidad = 2f;

    private Vector3 posicionInicial;
    private Vector3 posicionObjetivo;

    void Start()
    {
        posicionInicial = transform.localPosition;
        posicionObjetivo = posicionInicial;
    }

    public void AbrirPuerta(bool abrir)
    {
        if (abrir)
        {
            posicionObjetivo = posicionInicial + Vector3.down * distanciaApertura;
        }
        else
        {
            posicionObjetivo = posicionInicial;
        }
    }

    void Update()
    {
        // Interpolaci�n suave entre la posici�n actual y la posici�n objetivo
        transform.localPosition = Vector3.Lerp(transform.localPosition, posicionObjetivo, Time.deltaTime * velocidad);
    }
}

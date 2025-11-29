using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EasterEggInteract : MonoBehaviour
{
    public Image imagenEasterEgg;    // Arrastra aquí la imagen UI desde el Canvas
    public float tiempoMostrado = 3f;

    private bool jugadorCerca = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }
    }

    private void Update()
    {
        // ? CAMBIO A BARRA ESPACIADORA
        if (jugadorCerca && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MostrarEasterEgg());
        }
    }

    IEnumerator MostrarEasterEgg()
    {
        imagenEasterEgg.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoMostrado);
        imagenEasterEgg.gameObject.SetActive(false);
    }
}

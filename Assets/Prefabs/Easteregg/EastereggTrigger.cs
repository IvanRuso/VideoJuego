using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EasterEggTrigger : MonoBehaviour
{
    public Image imagenEasterEgg;
    public float tiempoVisible = 3f;

    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(MostrarImagen());
        }
    }

    private IEnumerator MostrarImagen()
    {
        imagenEasterEgg.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoVisible);
        imagenEasterEgg.gameObject.SetActive(false);
    }

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
}
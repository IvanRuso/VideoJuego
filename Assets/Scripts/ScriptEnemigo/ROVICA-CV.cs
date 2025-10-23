using UnityEngine;

public class ROVICA_CV : MonoBehaviour
{
    private AIROVICA ai;

    void Start()
    {
        ai = GetComponentInParent<AIROVICA>();
        if (ai == null)
            Debug.LogError("No se encontró AIROVICA en el padre.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ai.persiguiendo = true;

            // Detenemos la corutina de volver a patrulla si está activa
            if (ai.corutinaVolverPatrulla != null)
            {
                ai.StopCoroutine(ai.corutinaVolverPatrulla);
                ai.corutinaVolverPatrulla = null;
            }

            // Reanudamos el agente
            ai.ReanudarAgente();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ai.persiguiendo = false;
            ai.corutinaVolverPatrulla = ai.StartCoroutine(ai.EsperarAntesDeVolverPatrulla());
        }
    }
}

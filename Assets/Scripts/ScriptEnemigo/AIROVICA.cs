using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIROVICA : MonoBehaviour
{
    [Header("Patrulla")]
    public Transform[] puntosPatrulla;
    private int indice = 0;
    public float tiempoEsperaPunto = 2f;
    public float tiempoEsperaAntesDeVolver = 1f;

    [HideInInspector] public bool persiguiendo = false;
    [HideInInspector] public Coroutine corutinaVolverPatrulla;
    private bool esperando = false;

    private Transform jugador;
    private NavMeshAgent agente;
    private Transform puntoRespawn;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player")?.transform;
        agente = GetComponent<NavMeshAgent>();

        GameObject respawnObj = GameObject.Find("Respawn");
        if (respawnObj != null)
            puntoRespawn = respawnObj.transform;

        if (puntosPatrulla.Length > 0)
            agente.SetDestination(puntosPatrulla[0].position);
    }

    void Update()
    {
        if (persiguiendo && jugador != null)
        {
            agente.SetDestination(jugador.position);
        }
        else if (!esperando && puntosPatrulla.Length > 0 &&
                 Vector3.Distance(transform.position, puntosPatrulla[indice].position) <= 0.6f)
        {
            StartCoroutine(EsperarEnPunto());
        }
    }

    IEnumerator EsperarEnPunto()
    {
        esperando = true;
        agente.isStopped = true;
        yield return new WaitForSeconds(tiempoEsperaPunto);
        agente.isStopped = false;

        indice = (indice + 1) % puntosPatrulla.Length;
        agente.SetDestination(puntosPatrulla[indice].position);
        esperando = false;
    }

    public IEnumerator EsperarAntesDeVolverPatrulla()
    {
        esperando = true;
        agente.isStopped = true;
        yield return new WaitForSeconds(tiempoEsperaAntesDeVolver);
        agente.isStopped = false;

        if (puntosPatrulla.Length > 0)
            agente.SetDestination(puntosPatrulla[indice].position);

        esperando = false;
    }

    public void ReanudarAgente()
    {
        if (agente.isStopped)
            agente.isStopped = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (puntoRespawn != null)
                collision.gameObject.transform.position = puntoRespawn.position;

            VidaPlayer vidaJugador = collision.gameObject.GetComponent<VidaPlayer>();
            if (vidaJugador != null)
                vidaJugador.Daño(1);
        }
    }
}

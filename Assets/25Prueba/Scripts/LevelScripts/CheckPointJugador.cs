using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointJugador : MonoBehaviour
{
    public GameObject Jugador;
    private RespawnJugador respawnJugador;

    private bool checKpointActivado = false;
    public int sfxToPlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!checKpointActivado)
            {
                Jugador = other.gameObject;
                respawnJugador = Jugador.GetComponent<RespawnJugador>();
                respawnJugador.setSpawnPoint(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z ));//establece el nuevo puntode spawn 
                respawnJugador.disponible = true;
                checKpointActivado = true;

                sfxToPlay = 9;
                AudioManager.instance.SoundEffects(sfxToPlay);
            }   
        }
    }

    
}

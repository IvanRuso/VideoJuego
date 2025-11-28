using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escaparNivel : MonoBehaviour
{
    public GameObject Jugador;
    public capturarAnimal animalCheckpoint;

    private RespawnJugador respawnJugador;

    //private bool animalCapturado = false;
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
            if (animalCheckpoint.animalCapturado)//si el animal ya fue capturado
            {
                GameManager.instance.escaparNivel();
            }
        }
    }
}

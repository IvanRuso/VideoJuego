using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] public GameObject Jugador;
    private VidaPlayer vidaJugador;
    private MovePlayer moveJugador;



    [SerializeField] public GameObject CheckPointIncial;
    [SerializeField] public GameObject AnimalObjetivo;

    // Start is called before the first frame update
    void Start()
    {
        vidaJugador = Jugador.GetComponent<VidaPlayer>();
        moveJugador = Jugador.GetComponent <MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaJugador.Vida == 0)
        {
            ReiniciarNivel();
        }
       
    }

    private void ReiniciarNivel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}

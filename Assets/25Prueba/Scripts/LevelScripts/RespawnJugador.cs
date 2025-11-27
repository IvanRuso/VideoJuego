using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnJugador : MonoBehaviour
{
    [SerializeField] GameObject LevelController;
    private LevelController nivel;

    public Vector3 respawnPoint;
    
    private MovePlayer movePlayer;
    private VidaPlayer vidaPlayer;

    public bool disponible = true;
    



    // Start is called before the first frame update
    void Start()
    {
        movePlayer = GetComponent<MovePlayer>();
        vidaPlayer = GetComponent<VidaPlayer>();
        
        nivel = LevelController.GetComponent<LevelController>();
        respawnPoint = nivel.CheckPointIncial.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


    public void RespawnPlayer()//envia al jugador al punto de respawn 
    {
        if (disponible)
        {
            StartCoroutine(RespawnWaiter());
            
        }

    }

    public void setSpawnPoint(Vector3 newSpawnPoint)//actualiza el punto de spawn
    {
        respawnPoint = newSpawnPoint;
    }

    public IEnumerator RespawnWaiter()
    {
        
        UIManager.instance.fadeToBlack = true;
        disponible = false;
        yield return new WaitForSeconds(2f);
        this.transform.position = respawnPoint;
        UIManager.instance.fadeFromBlack = true;
        
    }

   
}

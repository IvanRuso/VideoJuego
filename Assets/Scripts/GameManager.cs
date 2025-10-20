using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3 posicionRespawn;

    public int currentCoins;
    public int sfxToPlay;
    public int levelEndMusic;

    public string levelToLoad;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //posicionRespawn = PlayerMovement.instance.transform.position;
        UIManager.instance.pauseScreen.SetActive(false);
        AddCoins(0);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
            sfxToPlay = 4;
            AudioManager.instance.SoundEffects(sfxToPlay);
        }
    }

    public void Respawn()
    {
        sfxToPlay = 13;
        AudioManager.instance.SoundEffects(sfxToPlay);
        StartCoroutine(RespawnWaiter());
        //HealthManager.instance.PlayerKilled();
    }

    public IEnumerator RespawnWaiter()
    {
        //PlayerMovement.instance.gameObject.SetActive(false);
        //CameraController.instance.CinemaBrain.enabled = false;
        UIManager.instance.fadeToBlack = true;

        yield return new WaitForSeconds(2f);

        UIManager.instance.fadeFromBlack = true;
        //PlayerMovement.instance.transform.position = posicionRespawn;
        //CameraController.instance.CinemaBrain.enabled = true;
        //PlayerMovement.instance.gameObject.SetActive(true);

        //HealthManager.instance.ResetHealth();
    }

    public void setSpawnPoint(Vector3 newSpawnPoint)
    {
        posicionRespawn = newSpawnPoint;
        sfxToPlay = 9;
        AudioManager.instance.SoundEffects(sfxToPlay);
        //Debug.Log("Spawn Set");
    }

    public void AddCoins(int coinsToAdd)
    {
        currentCoins += coinsToAdd;
        UIManager.instance.coinText.text = currentCoins.ToString();
    }

    public void PauseUnpause()
    {
        if (UIManager.instance.pauseScreen.activeInHierarchy)
        {
            UIManager.instance.pauseScreen.SetActive(false);
            Time.timeScale = 1f;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            


        }
        else
        {
            UIManager.instance.pauseScreen.SetActive(true);
            UIManager.instance.CloseOptions();
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            sfxToPlay = 7;
            AudioManager.instance.SoundEffects(sfxToPlay);
        }
    }

    public IEnumerator LevelEndWaiter()
    {
        AudioManager.instance.StopMusic(AudioManager.instance.bgmMusic);
        AudioManager.instance.PlayMusic(levelEndMusic);
        //PlayerMovement.instance.stopMove = true;
        yield return new WaitForSeconds(3f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(levelToLoad);
    }
}

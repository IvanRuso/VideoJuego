using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Image PantallaNegra;
    public float fadeSpeed;
    public bool fadeToBlack, fadeFromBlack;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinText;

    public GameObject pauseScreen;
    public GameObject OptionsPanel;
    public string mainMenu;
    //public string levelSelect;

    public Slider masterVolumeSlider, musicVolumeSlider, sfxVolumeSlider;

    public int sfxToPlay;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            PantallaNegra.color = new Color(PantallaNegra.color.r, PantallaNegra.color.g, PantallaNegra.color.b, Mathf.MoveTowards(PantallaNegra.color.a, 1f, fadeSpeed * Time.deltaTime));

            if(PantallaNegra.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
        if (fadeFromBlack)
        {
            PantallaNegra.color = new Color(PantallaNegra.color.r, PantallaNegra.color.g, PantallaNegra.color.b, Mathf.MoveTowards(PantallaNegra.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (PantallaNegra.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void Resume()
    {
        GameManager.instance.PauseUnpause();
        sfxToPlay = 8;
        //AudioManager.instance.SoundEffects(sfxToPlay);
    }

    public void OpenOptions()
    {
        OptionsPanel.SetActive(true);
        sfxToPlay = 6;
        //AudioManager.instance.SoundEffects(sfxToPlay);
    }

    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);
        sfxToPlay = 1;
        //AudioManager.instance.SoundEffects(sfxToPlay);
    }

    /*public void LevelSelect()
    {
        sfxToPlay = 8;
        //AudioManager.instance.SoundEffects(sfxToPlay);
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }*/

    public void MainMenu()
    {
        sfxToPlay = 8;
        //AudioManager.instance.SoundEffects(sfxToPlay);
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    public void SetMasterLevel()
    {
        AudioManager.instance.SetMasterLevel();
    }
    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();
    }
    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }
    
}

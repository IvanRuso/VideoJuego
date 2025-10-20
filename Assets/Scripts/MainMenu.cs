using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public string levelSelect;
    public string mainMenu;
    public string secondLevel;
    public int sfxToPlay;

    public GameObject optionsPanel;
    public GameObject creditsPanel;

    public void NewGame()
    {
        sfxToPlay = 8;
        ////AudioManager.instance.SoundEffects(sfxToPlay);
        SceneManager.LoadScene(firstLevel);
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        sfxToPlay = 8;
        //AudioManager.instance.SoundEffects(sfxToPlay);
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void LevelTwo()
    {
        sfxToPlay = 8;
        //AudioManager.instance.SoundEffects(sfxToPlay);
        SceneManager.LoadScene(secondLevel);
        Time.timeScale = 1f;
    }

    public void ReturnMainMenu()
    {
        sfxToPlay = 8;
        //AudioManager.instance.SoundEffects(sfxToPlay);
        SceneManager.LoadScene(mainMenu);
    }
  
    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        sfxToPlay = 6;
        //AudioManager.instance.SoundEffects(sfxToPlay);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
        sfxToPlay = 6;
        //AudioManager.instance.SoundEffects(sfxToPlay);
    }
    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
        sfxToPlay = 1;
        //AudioManager.instance.SoundEffects(sfxToPlay);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        sfxToPlay = 1;
        //AudioManager.instance.SoundEffects(sfxToPlay);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();
    }

    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }

    public void SetMasterLevel()
    {
        AudioManager.instance.SetMasterLevel();
    }
}

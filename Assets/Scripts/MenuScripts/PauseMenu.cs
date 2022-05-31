using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public bool optionsMenuOn = false;
    public GameObject gameUI;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public AudioSource MenuAudioSource;
    public AudioClip MainMenuUPAudio;
    public AudioClip MainMenuDownAudio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (optionsMenuOn == false)
            {
                if (gamePaused == true)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
            
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
        MenuDownPlayAudio();
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        gameUI.SetActive(false);
        MenuUPPlayAudio();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        gamePaused = false;
        MenuDownPlayAudio();
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    public void OptionsMenuChange()
    {
        optionsMenuOn = !optionsMenuOn;
    }

    public void MenuUPPlayAudio()
    {
        MenuAudioSource.PlayOneShot(MainMenuUPAudio);
    }

    public void MenuDownPlayAudio()
    {
        MenuAudioSource.PlayOneShot(MainMenuDownAudio);
    }
}

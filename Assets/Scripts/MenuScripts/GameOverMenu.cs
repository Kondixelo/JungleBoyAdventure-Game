using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private bool isGameOver;
    [SerializeField] GameObject player;
    public GameObject gameOverMenu;

    public AudioSource MenuAudioSource;
    public AudioClip MainMenuUPAudio;
    public AudioClip MainMenuDownAudio;
    public AudioClip GameOverMenuAudio;

    private bool playGemOverAudio;
    void Start()
    {
        isGameOver = false;
        playGemOverAudio = true;
    }

    void Update()
    {
        if (isGameOver)
        {
            if (playGemOverAudio)
            {
                MenuAudioSource.PlayOneShot(GameOverMenuAudio);
                playGemOverAudio = false;
                Time.timeScale = 0f;
                gameOverMenu.SetActive(true);
            }
        }          
    }

    public void GameOverStatusChange()
    {
        isGameOver = true;
    }

    public void RestartGame()
    { 
        Time.timeScale = 1f;
        MenuUPPlayAudio();
        SceneManager.LoadScene("Game");     
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        MenuDownPlayAudio();
        SceneManager.LoadScene("Menu");    
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

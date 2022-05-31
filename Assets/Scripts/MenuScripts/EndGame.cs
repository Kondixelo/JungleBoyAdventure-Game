using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private bool isGameEnd;
    [SerializeField] GameObject player;
    public GameObject gameEndMenu;
    public GameObject gameUI;

    public AudioSource MenuAudioSource;
    public AudioClip MainMenuDownAudio;
    public AudioClip GameEndMenuAudio;


    public GameObject mainSliderObject;
    private SoundManagerMain soundMainMan;
    private float volumeMenu;

    private bool playGemEndAudio;
    void Start()
    {
        isGameEnd = false;
        playGemEndAudio = true;
        soundMainMan = mainSliderObject.GetComponent<SoundManagerMain>();
    }

    void Update()
    {
        if (isGameEnd)
        {
            if (playGemEndAudio)
            {
                MenuAudioSource.PlayOneShot(GameEndMenuAudio);
                playGemEndAudio = false;
                Time.timeScale = 0f;
                gameEndMenu.SetActive(true);
                gameUI.SetActive(false);
                volumeMenu = soundMainMan.MuteMain();
            }
        }
    }

    public void GameEndStatusChange()
    {
        isGameEnd = true;
    }   

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        AudioListener.volume = volumeMenu;
        MenuDownPlayAudio();
        SceneManager.LoadScene("Menu");
    }

    public void MenuDownPlayAudio()
    {
        MenuAudioSource.PlayOneShot(MainMenuDownAudio);
    }
}
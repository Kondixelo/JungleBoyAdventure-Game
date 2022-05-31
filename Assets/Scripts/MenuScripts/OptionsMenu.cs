using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsMenuUI;
    public GameObject MenuCanvas;

    private PauseMenu pauseMenuObject; //potrzebne do zmiany zmiennej 'optionsMenuOn'
    public AudioSource MenuAudioSource;
    public AudioClip MainMenuUPAudio;
    public AudioClip MainMenuDownAudio;

    void Awake()
    {
        pauseMenuObject = MenuCanvas.GetComponent<PauseMenu>();

    }

    private void Start()
    {
        optionsMenuUI.SetActive(false);
    }
    void Update()
    {
        if(pauseMenuObject.optionsMenuOn == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                MenuAudioSource.PlayOneShot(MainMenuDownAudio);
                optionsMenuUI.SetActive(false);
                pauseMenuObject.OptionsMenuChange();
            }
        } 
    }
}

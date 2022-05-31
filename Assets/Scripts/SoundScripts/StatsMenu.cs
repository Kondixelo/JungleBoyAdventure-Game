using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsMenu : MonoBehaviour
{
    public GameObject statsMenuUI;

    public AudioSource StatsMenuAudioSource;
    private bool playAudio;
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (playAudio)
            {
                StatsMenuAudioSource.Play();
                playAudio = false;
            }          
            statsMenuUI.SetActive(true);
        }
        else
        {
            playAudio = true;
            statsMenuUI.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            StatsMenuAudioSource.Play();
        }
        
    }
}

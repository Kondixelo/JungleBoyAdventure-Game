using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    public AudioSource MenuAudioSource;
    public AudioClip MainMenuUPAudio;
    public AudioClip MainMenuDownAudio;

    public void MenuUPPlayAudio()
    {
        MenuAudioSource.PlayOneShot(MainMenuUPAudio);
    }

    public void MenuDownPlayAudio()
    {
        MenuAudioSource.PlayOneShot(MainMenuDownAudio);
    }
}

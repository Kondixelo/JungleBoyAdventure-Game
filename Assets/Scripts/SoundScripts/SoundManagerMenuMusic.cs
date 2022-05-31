using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManagerMenuMusic : MonoBehaviour
{
    public GameObject musicObject;
    private AudioSource[] musicMenuSources;
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        musicMenuSources = musicObject.GetComponents<AudioSource>();
        if (!PlayerPrefs.HasKey("musicMenuVolume"))
        {
            PlayerPrefs.SetFloat("musicMenuVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        musicMenuSources[1].volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicMenuVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicMenuVolume", volumeSlider.value);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManagerAmbient : MonoBehaviour
{
    public GameObject ambientObject;
    private AudioSource ambientSource;
    [SerializeField] Slider volumeSlider;
    void Start()
    {
        ambientSource = ambientObject.GetComponent<AudioSource>();
        if (!PlayerPrefs.HasKey("ambientVolume"))
        {
            PlayerPrefs.SetFloat("ambientVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        ambientSource.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("ambientVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("ambientVolume", volumeSlider.value);
    }
}
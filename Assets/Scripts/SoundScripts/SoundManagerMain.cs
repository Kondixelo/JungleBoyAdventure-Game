using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerMain : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private float volumeMain;
    void Start()
    {
        if (!PlayerPrefs.HasKey("mainVolume"))
        {
            PlayerPrefs.SetFloat("mainVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("mainVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("mainVolume", volumeSlider.value);
    }

    public float MuteMain()
    {
        volumeMain = AudioListener.volume;
        AudioListener.volume = 0;
        return volumeMain;
    }
}

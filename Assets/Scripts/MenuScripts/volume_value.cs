using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TextCore;
using TMPro;
using System;

public class volume_value : MonoBehaviour { 
    public GameObject slider;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] GameObject textObject;

    private float volumeValue;
    private string newText;

    void Start()
    {
        volumeText = textObject.GetComponent<TextMeshProUGUI>();
        volumeValue = slider.GetComponent<Slider>().value;
        if ((volumeValue > 0) && (volumeValue < 1))
        {
            newText = "0" + volumeValue.ToString("#.##");
            if (newText.Length < 4)
            {
                newText = "0" + volumeValue.ToString("#.##") + "0";
            }
            volumeText.text = newText;
        }
        if (volumeValue == 1)
        {
            volumeText.text = "1,00";
        }
        if (volumeValue == 0)
        {
            volumeText.text = "0,00";
        }

    }
    public void TextChange()
    {
        volumeValue = slider.GetComponent<Slider>().value;
        if ((volumeValue > 0) && (volumeValue < 1))
        {
            newText = "0" + volumeValue.ToString("#.##");
            if (newText.Length < 4)
            {
                newText = "0" + volumeValue.ToString("#.##") + "0";
            }
            volumeText.text = newText;
        }
        if (volumeValue == 1)
        {
            volumeText.text = "1,00";
        }
        if (volumeValue == 0)
        {
            volumeText.text = "0,00";
        }
    }
}

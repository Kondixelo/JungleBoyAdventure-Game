using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarEnemies : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
  
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        slider.fillRect.GetComponent<Image>().color = Color.green;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        slider.fillRect.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, slider.value/100);
    }

}

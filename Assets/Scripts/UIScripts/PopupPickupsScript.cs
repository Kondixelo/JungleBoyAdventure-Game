using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupPickupsScript : MonoBehaviour
{
    public GameObject textObject;
    private TMP_Text tmp_text;

    void Start()
    {
        tmp_text = textObject.GetComponent<TMP_Text>();
        tmp_text.text = "";
    }

    public void UpdatePopup(string popupText)
    {
        tmp_text.text = popupText;
        Invoke("ClearPopup", 6f);
    }

    public void ClearPopup()
    {
        tmp_text.text = "";
    }
}

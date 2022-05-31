using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class popup : MonoBehaviour
{
    public Transform checkPlayer;
    public float checkPlayerRadius;
    public LayerMask whatIsPlayer;
    private bool isPlayer;

    public GameObject popupMiejsce;

    void Update()
    {
        if (isPlayer)
        {
            popupMiejsce.SetActive(true);
        }
        else
        {
            popupMiejsce.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        isPlayer = Physics2D.OverlapCircle(checkPlayer.position, checkPlayerRadius, whatIsPlayer);
    }
}

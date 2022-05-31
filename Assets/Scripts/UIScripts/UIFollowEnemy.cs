using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowEnemy : MonoBehaviour
{
    public Transform enemyToFollow;
    RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(enemyToFollow != null)
        {
            rectTransform.anchoredPosition = enemyToFollow.localPosition;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameSign : MonoBehaviour
{
    public Transform checkPlayer;
    public float checkPlayerRadius;
    public LayerMask whatIsPlayer;
    private bool isPlayer;

    public GameObject menuEndGameObject;
    public GameObject menuObject;
    private EndGame menuEndGameVariable;
    void Start()
    {
        menuEndGameVariable = menuObject.GetComponent<EndGame>();
    }

    void Update()
    {
        if (isPlayer)
        {
            menuEndGameVariable.GameEndStatusChange();
        } 
    }
    private void FixedUpdate()
    {
        isPlayer = Physics2D.OverlapCircle(checkPlayer.position, checkPlayerRadius, whatIsPlayer);
    }
}


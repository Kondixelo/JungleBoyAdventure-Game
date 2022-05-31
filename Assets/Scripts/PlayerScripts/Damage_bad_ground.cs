using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Damage_bad_ground : MonoBehaviour
{
    [SerializeField] GameObject player;

    private zycieGracz playerHP;

    public Transform checkBadGround;
    public float checkingRadius;
    public LayerMask whatIsBadGround;


    private bool onBadGround;
    public bool takeDamageToPlayer;

    void Start()
    {
        playerHP = player.GetComponent<zycieGracz>();
        takeDamageToPlayer = true;
    }
 
    void FixedUpdate()
    {
        onBadGround = Physics2D.OverlapCircle(checkBadGround.position, checkingRadius, whatIsBadGround);
    }

    public void ChangeTakeDamage()
    {
        takeDamageToPlayer = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (onBadGround)
        {
            if (takeDamageToPlayer)
            {
                playerHP.TakeDamage(5);
                takeDamageToPlayer = false;
                Invoke("ChangeTakeDamage", 1f);
            }
        }   
    }
}

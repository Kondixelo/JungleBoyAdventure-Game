using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFromEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;

    private zycieGracz playerHP;
    private graczStats playerStats;

    public Transform checkEnemy; // obiekt ktory sprawdza
    public float checkingRadius;
    public LayerMask whatIsEnemy;
    Rigidbody2D rb;

    public bool takeDamageToPlayer;

    private float movementSpeed;

    void Start()
    {
        playerStats = player.GetComponent<graczStats>();
        playerHP = player.GetComponent<zycieGracz>();
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = playerStats.StatsMovementSpeed();
        takeDamageToPlayer = true;
    }

    void Update()
    {
        var movementHor = Input.GetAxis("Horizontal");
    }

    public void ChangeTakeDamage()
    {
        takeDamageToPlayer = true;
    }

    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            //knockback
            //playerHP.TakeDamage(10);
            //transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 20;
            if (takeDamageToPlayer)
            {
                playerHP.TakeDamage(5);
                takeDamageToPlayer = false;
                Invoke("ChangeTakeDamage", 1f);
            }
        }

    }


}

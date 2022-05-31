using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public GameObject deathEffect;
    public float speed;
    public float direction; // 1 w prawo; -1 w lewo
    public AudioSource EnemyHitAudioSource;
    public GameObject enemy;
    private healthBarEnemies healthEnemy;
    public void TakeDamage(int damage)
    {
        EnemyHitAudioSource.Play();
        health -= damage;
        healthEnemy.SetHealth(health);
        if (health <= 0) 
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Die(); 
        }
    }

    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void Start()
    {
        InvokeRepeating("ChangeDirection", 2f, 2f);
        healthEnemy = enemy.GetComponent<healthBarEnemies>();
        healthEnemy.SetMaxHealth(maxHealth);
        health = maxHealth;
    }

    void Update()
    {
        transform.position += new Vector3(direction, 0f, 0) * Time.deltaTime * speed;
    }

    public void ChangeDirection()
    {
        direction = -direction;
    }
}

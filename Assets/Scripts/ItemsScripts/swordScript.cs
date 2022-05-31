using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class swordScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public int damage;
    public Rigidbody2D rb;

    public int counter;
    private float nextActionTime = 0.0f;
    public float period = 1f;

    [SerializeField] GameObject player;
    private gracz_Attack graczAttackVariable;
    public bool speedPUGained;
    public bool damagePUGained;

    void Awake()
    {
        player = GameObject.Find("Gracz");
    }

    void Start()
    { 
        rb.velocity = transform.right * speed;
        counter = 0;
        graczAttackVariable = player.GetComponent<gracz_Attack>();
        speedPUGained = graczAttackVariable.SpeedPUStatusGet();
        damagePUGained = graczAttackVariable.DamagePUStatusGet();

        if (speedPUGained)
        {
            speed = 40f;
        }
        else
        {
            speed = 20f;
        }
        if (damagePUGained)
        {
            damage = 10;
        }
        else
        {
            damage = 5;
        }
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Tilemap tileMAP = hitInfo.GetComponent<Tilemap>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if(tileMAP != null)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            counter += 1;
            if (counter == 2)
            {
                Destroy(gameObject);
            }
        }
    }
}

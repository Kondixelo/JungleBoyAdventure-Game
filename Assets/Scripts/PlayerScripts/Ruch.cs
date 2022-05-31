using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruch : MonoBehaviour
{
    [SerializeField] GameObject player;
    private graczStats statyGracza;
    private float szybkoscRuchu;
    private float silaSkoku;
    private Rigidbody2D rb;

    public Transform sprawdzeniePodloza;// obiekt ktory sprawdza
    public float promienSprawdzaniaPodloza;
    public LayerMask coJestPodlozem;
    public LayerMask whatIsBadGround;
    private bool naPodlozu;
    private bool onGround;// jesli true to gracz jest na podlozu

    private int dodSkoki;

    private bool wPrawo = true;
    private bool czyLadowanie = true;


    private Animator anim;

    private float predkoscY;

    public AudioSource playerAudioSource;


    void Awake()
    {
        statyGracza = player.GetComponent<graczStats>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        anim.SetBool("czySpada", true);
        silaSkoku = statyGracza.StatsJumpForce();
    }

    void Update()
    {
        var movementHor = Input.GetAxis("Horizontal");
        var movementVer = Input.GetAxis("Vertical");
        predkoscY = rb.velocity.y;
        anim.SetInteger("liczbaSkokow", dodSkoki);

        if (naPodlozu || onGround) {
            dodSkoki = statyGracza.StatsExtraJumps();
            transform.position += new Vector3(movementHor, 0, 0) * Time.deltaTime * szybkoscRuchu;
            szybkoscRuchu = statyGracza.StatsMovementSpeed();
            anim.SetFloat("szybkoscRuchu", szybkoscRuchu);
            
            czyLadowanie = false;
            anim.SetBool("czySpada", false);
            anim.SetBool("czySkacze", false);
            anim.SetBool("czyLaduje", false);
            anim.SetBool("naZiemi", true);
        }
        else
        {
            szybkoscRuchu = szybkoscRuchu * (0.9995f);
            anim.SetFloat("szybkoscRuchu", szybkoscRuchu);
            transform.position += new Vector3(movementHor, 0, 0) * Time.deltaTime * szybkoscRuchu;
        }

        if (Input.GetKeyDown(KeyCode.W) && dodSkoki > 0)
        {
            Jump2();
            dodSkoki--;
        }
        if (Input.GetKeyDown(KeyCode.W) && dodSkoki < 0 && (naPodlozu || onGround))
        {
            Jump2();
        }


        if (movementHor == 0)
        {
            anim.SetBool("czyBiegnie", false);
        }
        else
        {
            if (movementHor > 0 && !wPrawo)
            {
                Flip(); //odwracanie animacji
            }else if (movementHor < 0 && wPrawo)
            {
                Flip();
            }
            anim.SetBool("czyBiegnie", true);
        }
       
        if(rb.velocity.y > 0){ //wyskoczyl
            szybkoscRuchu = statyGracza.StatsMovementSpeed(); 
            czyLadowanie = true;
            anim.SetBool("czySkacze", true);
            anim.SetBool("naZiemi", false);
            anim.SetBool("czyLaduje", false);
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("naZiemi", false);
            if (czyLadowanie == true) { anim.SetBool("czyLaduje", true); }
            else { anim.SetBool("czySpada", true); }
        }
        if(rb.velocity.y == 0)
        {
            anim.SetBool("czyLaduje", true);
            if (czyLadowanie == true){
                anim.SetBool("czyLaduje", true);
                czyLadowanie = false;
            }
            
            anim.SetBool("naZiemi", true);
            anim.SetBool("czySkacze", false);
            anim.SetBool("czySpada", false);
        }


    }
    void FixedUpdate()
    {
        naPodlozu = Physics2D.OverlapCircle(sprawdzeniePodloza.position, promienSprawdzaniaPodloza, coJestPodlozem);
        onGround = Physics2D.OverlapCircle(sprawdzeniePodloza.position, promienSprawdzaniaPodloza, whatIsBadGround);
    }


    void Jump2()
    {
        playerAudioSource.Play();
        rb.velocity = Vector2.up * silaSkoku;
    }

    void Flip()
    {
        wPrawo = !wPrawo;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
       
    }

    public float ZwrocPredkosc()
    {
        return predkoscY;
    }
}


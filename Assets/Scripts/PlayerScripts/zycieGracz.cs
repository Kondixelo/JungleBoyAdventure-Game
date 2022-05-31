using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class zycieGracz : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject menus;

    private int pktZycie;

    private float predkoscY;

    private int obrazenia;

    private Ruch ruchGracza;
    private graczStats statyGracza;
    private GameOverMenu gameOverGraczMenu;

    public healthBar healthBar;
    private bool endGame;

    public GameObject textObject;
    public TMP_Text tmp_text;
    public string textDamage;

    public AudioSource DamageAudioSource;

    void Awake()
    {
        ruchGracza = player.GetComponent<Ruch>();
        statyGracza = player.GetComponent<graczStats>();
        gameOverGraczMenu = menus.GetComponent<GameOverMenu>();

    }
    void Start()
    {
        tmp_text = textObject.GetComponent<TMP_Text>();
        pktZycie = statyGracza.StatsHealth();
        healthBar.SetMaxHealth(pktZycie);
        obrazenia = 0;
        endGame = false;
        tmp_text.text = "";
    }

    void Update()
    {
        predkoscY = ruchGracza.ZwrocPredkosc();

        if (predkoscY < -30)
        {
            obrazenia = (int)((int)Mathf.Abs(predkoscY) * 0.5f);
        }
        if (predkoscY == 0)
        {
            TakeDamage(obrazenia);
            obrazenia = 0;
        }

        if (pktZycie <= 0)
        {
            gameOverGraczMenu.GameOverStatusChange();
        }

    }

    public void TakeDamage(int damage)
    {
        pktZycie -= damage;
        healthBar.SetHealth(pktZycie);
        textDamage = damage.ToString();
        
        if (damage > 0)
        {
            DamageAudioSource.Play();
            tmp_text.text = "-" + textDamage;
            Invoke("ClearPopuptext", 0.85f);
        }
    }

    public bool zycieZero()
    {
        return endGame;
    }

    public int CurrentHPGet()
    {
        return pktZycie;
    }
    public void ClearPopuptext()
    {
        tmp_text.text = "";
    }
}

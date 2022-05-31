using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sword_item_script : MonoBehaviour
{

    private bool gainedSword;
    public GameObject sword;
    public LayerMask playerObject;
    public Transform checkSword;
    private bool swordGained;

    [SerializeField] GameObject menuStatsElements;
    private StatsMenuElements statsElements;

    [SerializeField] GameObject player;
    private gracz_Attack attackVariable;
    
    

    public GameObject elementsObject;
    public GameObject powerUpsObject;
    public GameObject enemiesObject;

    [SerializeField] GameObject textPickup;
    private PopupPickupsScript popupScriptVariable;
    private string textPopup = "<#ffc830>HIDDEN SWORD<size=40%>\n<#ffffff>Enemies has been spawned</size>";
    public bool activatePopup;

    public AudioSource swordPickupAudioSource;

    void Start()
    {
        activatePopup = true;
        gainedSword = false;
        swordGained = false;
        statsElements = menuStatsElements.GetComponent<StatsMenuElements>();
        attackVariable = player.GetComponent<gracz_Attack>();
        popupScriptVariable = textPickup.GetComponent<PopupPickupsScript>();
    
    }
    void Update()
    {
        if (gainedSword)
        {
            elementsObject.SetActive(true);
            powerUpsObject.SetActive(true);
            enemiesObject.SetActive(true);
            statsElements.SwordStatusChange();
            attackVariable.SwordStatusChange();
            swordGained = true;
            sword.SetActive(false);

            if (activatePopup)
            {
                swordPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopup);
                activatePopup = false;
            }
        }
    }
    private void FixedUpdate()
    {
        gainedSword = Physics2D.OverlapCircle(checkSword.position,1, playerObject);
    }

    public bool SwordStatusGet()
    {
        return swordGained;
    }

}

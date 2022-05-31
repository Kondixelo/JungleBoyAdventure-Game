using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsScript : MonoBehaviour
{
    
    public float checkAngle;
    public LayerMask playerObject;

    [SerializeField] GameObject menuStatsElements;
    private StatsMenuElements statsElements;

    public GameObject barbarian;
    public Transform checkBarbarian;
    private bool gainedBarbarian;

    public GameObject berserker;
    public Transform checkBerserker;
    private bool gainedBerserker;

    public GameObject deathKnight;
    public Transform checkDeathKnight;
    private bool gainedDeathKnight;

    public GameObject dragonKnight;
    public Transform checkDragonKnight;
    private bool gainedDragonKnight;

    public GameObject guardian;
    public Transform checkGuardian;
    private bool gainedGuardian;


    [SerializeField] GameObject textPickup;
    private PopupPickupsScript popupScriptVariable;

    private bool activatePopupBarbarian;
    private bool activatePopupBerserker;
    private bool activatePopupDeathKnight;
    private bool activatePopupDragonKnight;
    private bool activatePopupGuardian;

    private string textPopupBarbarian = "<#ac71e3>Barbarian Element<size=40%>\n<#ffffff>You are overcome with a barbarian lust for murder</size>";
    private string textPopupBerserker = "<#ac71e3>Berserker Element<size=40%>\n<#ffffff>The berserker's rampage overwhelms you with every second</size>";
    private string textPopupDeathKnight = "<#ac71e3>Death Knight Element<size=40%>\n<#ffffff>You can fight with undead.</size>";
    private string textPopupDragonKnight = "<#ac71e3>Dragon Knight Element<size=40%>\n<#ffffff>You can cooperate with dragons</size>";
    private string textPopupGuardian = "<#ac71e3>Guardian Element<size=40%>\n<#ffffff>You obtain greater resistance from elements of nature</size>";

    public AudioSource ElementsPickupAudioSource;

    void Start()
    {
        popupScriptVariable = textPickup.GetComponent<PopupPickupsScript>();
        activatePopupBarbarian = true;
        activatePopupBerserker = true;
        activatePopupDeathKnight = true;
        activatePopupDragonKnight = true;
        activatePopupGuardian = true;
        statsElements= menuStatsElements.GetComponent<StatsMenuElements>();
    }

    void Update()
    {
        if (gainedBarbarian)
        {
            barbarian.SetActive(false);
            statsElements.BarbarianStatusChange();
            if (activatePopupBarbarian)
            {
                ElementsPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopupBarbarian);
                activatePopupBarbarian = false;
            }
            
        }
        if (gainedBerserker)
        {
            berserker.SetActive(false);
            statsElements.BerserkerStatusChange();
            if (activatePopupBerserker)
            {
                ElementsPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopupBerserker);
                activatePopupBerserker = false;
            }
            
        }
        if (gainedDeathKnight)
        {
            deathKnight.SetActive(false);
            statsElements.DeathKnightStatusChange();
            if (activatePopupDeathKnight)
            {
                ElementsPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopupDeathKnight);
                activatePopupDeathKnight = false;
            }
            
        }
        if (gainedDragonKnight)
        {
            dragonKnight.SetActive(false);
            statsElements.DragonKnightStatusChange();
            if (activatePopupDragonKnight)
            {
                ElementsPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopupDragonKnight);
                activatePopupDragonKnight = false;
            }
            
        }
        if (gainedGuardian)
        {
            guardian.SetActive(false);
            statsElements.GuardianStatusChange();
            if (activatePopupGuardian)
            {
                ElementsPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopupGuardian);
                activatePopupGuardian = false;
            }
            
        }
    }


    private void FixedUpdate()
    {
        gainedBarbarian = Physics2D.OverlapCircle(checkBarbarian.position, 0.5f, playerObject);
        gainedBerserker = Physics2D.OverlapCircle(checkBerserker.position, 0.5f, playerObject);
        gainedDeathKnight = Physics2D.OverlapCircle(checkDeathKnight.position, 0.5f, playerObject);
        gainedDragonKnight = Physics2D.OverlapCircle(checkDragonKnight.position, 0.5f, playerObject);
        gainedGuardian = Physics2D.OverlapCircle(checkGuardian.position, 0.5f, playerObject);
    }


    public bool BarbarianStatusGet()
    {
        return gainedBarbarian;
    }

    public bool BerserkerStatusGet()
    {
        return gainedBerserker;
    }

    public bool DeathKnightStatusGet()
    {
        return gainedDeathKnight;
    }

    public bool DragonKnightStatusGet()
    {
        return gainedDragonKnight;
    }

    public bool GuardianStatusGet()
    {
        return gainedGuardian;
    }
}

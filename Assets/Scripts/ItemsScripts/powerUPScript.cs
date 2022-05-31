using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUPScript : MonoBehaviour
{
    public float checkAngle;
    public LayerMask playerObject;

    [SerializeField] GameObject menuStatsElements;
    private StatsMenuElements statsElements;

    [SerializeField] GameObject player;
    private gracz_Attack graczAttackVariable;

    public GameObject doublePU;
    public Transform checkDoublePU;
    private bool gainedDoublePU;

    public GameObject damagePU;
    public Transform checkDamagePU;
    private bool gainedDamagePU;

    public GameObject speedPU;
    public Transform checkSpeedPU;
    private bool gainedSpeedPU;

    [SerializeField] GameObject textPickup;
    private PopupPickupsScript popupScriptVariable;

    private bool activatePopupDoublePU;
    private bool activatePopupDamagePU;
    private bool activatePopupSpeedPU;

    private string textPopupDoublePU = "<#26bdf0>Diamond Gem<size=40%>\n<#ffffff>Double Attack</size>";
    private string textPopupDamagePU = "<#26bdf0>Ruby Gem<size=40%>\n<#ffffff>+Damage Attack</size>";
    private string textPopupSpeedPU = "<#26bdf0>Topaz Gem<size=40%>\n<#ffffff>+Speed Attack</size>";

    public AudioSource PowerUPPickupAudioSource;
    void Start()
    {
        activatePopupDamagePU = true;
        activatePopupDoublePU = true;
        activatePopupSpeedPU = true;
        statsElements = menuStatsElements.GetComponent<StatsMenuElements>();
        graczAttackVariable = player.GetComponent<gracz_Attack>();
        popupScriptVariable = textPickup.GetComponent<PopupPickupsScript>();
    }

    void Update()
    {
        if (gainedDoublePU)
        {
            doublePU.SetActive(false);
            statsElements.DoublePUStatusChange();
            graczAttackVariable.DoublePUStatusChange();
            if (activatePopupDoublePU)
            {
                PowerUPPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopupDoublePU);
                activatePopupDoublePU = false;
            }
        }
        if (gainedDamagePU)
        {
            damagePU.SetActive(false);
            statsElements.DamagePUStatusChange();
            graczAttackVariable.DamagePUStatusChange();
            if (activatePopupDamagePU)
            {
                PowerUPPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopupDamagePU);
                activatePopupDamagePU = false;
            }
        }
        if (gainedSpeedPU)
        {
            speedPU.SetActive(false);
            statsElements.SpeedPUStatusChange();
            graczAttackVariable.SpeedPUStatusChange();
            if (activatePopupSpeedPU)
            {
                PowerUPPickupAudioSource.Play();
                popupScriptVariable.UpdatePopup(textPopupSpeedPU);
                activatePopupSpeedPU = false;
            }
        }
    }

    private void FixedUpdate()
    {
        gainedDoublePU = Physics2D.OverlapBox(checkDoublePU.position, checkDoublePU.localScale, checkAngle, playerObject);
        gainedDamagePU = Physics2D.OverlapBox(checkDamagePU.position, checkDamagePU.localScale, checkAngle, playerObject);
        gainedSpeedPU= Physics2D.OverlapBox(checkSpeedPU.position, checkSpeedPU.localScale, checkAngle, playerObject);
    }
    
    public bool DoublePUStatusGet()
    {
        return gainedDoublePU;
    }
    public bool DamagaePUStatusGet()
    {
        return gainedDamagePU;
    }
    public bool SpeedPUStatusGet()
    {
        return gainedSpeedPU;
    }
}

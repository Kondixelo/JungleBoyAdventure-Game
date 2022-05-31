using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenuElements : MonoBehaviour
{
    private bool barbarianGained;
    private bool berserkerGained;
    private bool deathKnightGained;
    private bool dragonKnightGained;
    private bool guardianGained;


    public Image barbarianImage;
    public Image berserkerImage;
    public Image deathKnightImage;
    public Image dragonKnightImage;
    public Image guardianImage;


    private bool swordGained;
    private bool doublePUGained;
    private bool speedPUGained;
    private bool damagePUGained;

    public Image swordImage;
    public Image doublePUImage;
    public Image damagePUImage;
    public Image speedPUImage;



    [SerializeField] GameObject menuStatsElements;
    private ElementsScript elementsScriptVariable;

    [SerializeField] GameObject menuStatsPU;
    private powerUPScript PUScriptVariable;

    /*
    [SerializeField] GameObject menuStatsSword;
    private Sword_item_script SwordScriptVariable;
    */

    //[SerializeField] GameObject player;
    //private gracz_Attack attackScript;
    void Start()
    {
        elementsScriptVariable = menuStatsElements.GetComponent<ElementsScript>();
        //attackScript = player.GetComponent<gracz_Attack>();
        barbarianGained = elementsScriptVariable.BarbarianStatusGet();
        berserkerGained = elementsScriptVariable.BerserkerStatusGet();
        deathKnightGained = elementsScriptVariable.DeathKnightStatusGet();
        dragonKnightGained = elementsScriptVariable.DragonKnightStatusGet();
        guardianGained = elementsScriptVariable.GuardianStatusGet();

        PUScriptVariable = menuStatsPU.GetComponent<powerUPScript>();

        doublePUGained = PUScriptVariable.DoublePUStatusGet();
        damagePUGained = PUScriptVariable.DamagaePUStatusGet();
        speedPUGained = PUScriptVariable.SpeedPUStatusGet();


        /*
        SwordScriptVariable = menuStatsSword.GetComponent<Sword_item_script>();

        swordGained = SwordScriptVariable.SwordStatusGet();
        */

    }

    void Update()
    {
        if (barbarianGained)
        {
            barbarianImage.enabled = true;
        }
        if (berserkerGained)
        {
            berserkerImage.enabled = true;
        }
        if (deathKnightGained)
        {
            deathKnightImage.enabled = true;
        }
        if (dragonKnightGained)
        {
            dragonKnightImage.enabled = true;
        }
        if (guardianGained)
        {
            guardianImage.enabled = true;
        }
        if (swordGained)
        {
            swordImage.enabled = true;
        }
        if (doublePUGained)
        {
            doublePUImage.enabled = true;
        }
        if (damagePUGained)
        {
            damagePUImage.enabled = true;
        }
        if (speedPUGained)
        {
            speedPUImage.enabled = true;
        }
    }


    public void BarbarianStatusChange()
    {
        barbarianGained = true;
    }

    public void BerserkerStatusChange()
    {
        berserkerGained = true;
    }

    public void DeathKnightStatusChange()
    {
        deathKnightGained = true;
    }

    public void DragonKnightStatusChange()
    {
        dragonKnightGained = true;
    }

    public void GuardianStatusChange()
    {
        guardianGained = true;
    }

    public void SwordStatusChange()
    {
        swordGained = true;
    }

    public void DoublePUStatusChange()
    {
        doublePUGained = true;
    }

    public void DamagePUStatusChange()
    {
        damagePUGained = true;
    }

    public void SpeedPUStatusChange()
    {
        speedPUGained = true;
    }
    public bool SpeedPUStatusGet()
    {
        return speedPUGained;
    }
    public bool DamagePUStatusGet()
    {
        return damagePUGained;
    }

    public bool DoublePUStatusGet()
    {
        return doublePUGained;
    }
}

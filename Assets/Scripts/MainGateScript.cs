using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGateScript : MonoBehaviour
{
    [SerializeField] GameObject menuStatsElements;
    private ElementsScript elementsScriptVariable;

    public GameObject gate;
    public GameObject signInfoClosed;
    public GameObject signInfoOpen;

    private bool barbarianCollected;
    private bool berserkerCollected;
    private bool deathKnightCollected;
    private bool dragonKnightCollected;
    private bool guardianCollected;

    public AudioSource GateOpenAudioSource;
    private bool playGateOpenAudio;

    void Start()
    {
        playGateOpenAudio = true;
        elementsScriptVariable = menuStatsElements.GetComponent<ElementsScript>();
    }

    void Update()
    {     
        if (elementsScriptVariable.BarbarianStatusGet() == true)
        {
            barbarianCollected = true;
        }
        if (elementsScriptVariable.BerserkerStatusGet() == true)
        {
            berserkerCollected = true;
        }
        if (elementsScriptVariable.DeathKnightStatusGet() == true)
        {
            deathKnightCollected = true;
        }
        if (elementsScriptVariable.DragonKnightStatusGet() == true)
        {
            dragonKnightCollected = true;
        }
        if (elementsScriptVariable.GuardianStatusGet() == true)
        {
            guardianCollected = true;
        }

        if (barbarianCollected == true &&
            berserkerCollected == true &&
            deathKnightCollected == true &&
            dragonKnightCollected == true &&
            guardianCollected == true)
        {
            if (playGateOpenAudio)
            {
                GateOpenAudioSource.Play();
                playGateOpenAudio = false;
            }
            gate.SetActive(false);
            signInfoClosed.SetActive(false);
            signInfoOpen.SetActive(true);
            
        }
    }
}

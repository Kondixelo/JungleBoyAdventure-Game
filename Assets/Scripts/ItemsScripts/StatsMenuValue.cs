using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenuValue : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI hpCurrentText;
    [SerializeField] TextMeshProUGUI movSpeedText;
    [SerializeField] TextMeshProUGUI jumpForceText;
    private graczStats statyGracza;
    private zycieGracz zycieGracza;
    private int hpValueStat;
    private int hpCurrentValueStat;
    private float movSpeedValueStat;
    private float jumpForceValueStat;
    private string valueText;

    void Awake()
    {
        statyGracza = player.GetComponent<graczStats>();
        zycieGracza = player.GetComponent<zycieGracz>();
    }

    void Start()
    {
        hpText = GameObject.Find("hp_value").GetComponent<TextMeshProUGUI>();
        hpCurrentText = GameObject.Find("hpC_value").GetComponent<TextMeshProUGUI>();
        movSpeedText = GameObject.Find("mv_value").GetComponent<TextMeshProUGUI>();
        jumpForceText = GameObject.Find("fj_value").GetComponent<TextMeshProUGUI>();
     
    }
    void Update()
    {
        hpTextChange();
        movSpeedTextChange();
        jumpForceTextChange();
        hpCurrentTextChange();
    }

    public void hpTextChange()
    {
        hpValueStat = statyGracza.StatsHealth();
        valueText = hpValueStat.ToString();
        hpText.text = valueText;
    }
    public void movSpeedTextChange()
    {
        movSpeedValueStat = statyGracza.StatsMovementSpeed();
        valueText = movSpeedValueStat.ToString();
        movSpeedText.text = valueText;
    }
    public void jumpForceTextChange()
    {
        jumpForceValueStat = statyGracza.StatsJumpForce();
        valueText = jumpForceValueStat.ToString();
        jumpForceText.text = valueText;
    }
    public void hpCurrentTextChange()
    {
        hpCurrentValueStat = zycieGracza.CurrentHPGet();
        valueText = hpCurrentValueStat.ToString();
        hpCurrentText.text = valueText;
    }
}

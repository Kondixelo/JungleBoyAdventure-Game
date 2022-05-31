using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gracz_Attack : MonoBehaviour
{
    private bool doublePUGained;
    private bool speedPUGained;
    private bool damagePUGained;

    private bool swordGained;

    public Transform firePoint;

    public GameObject bulletPrefab;
    [SerializeField] GameObject swordItemObject;
    private Sword_item_script swordScriptVariable;
    public AudioSource swordAudioSource;

    void Start()
    {
        swordScriptVariable = swordItemObject.GetComponent<Sword_item_script>();
        swordGained = swordScriptVariable.SwordStatusGet();
    }


    void Update() 
    {
        if (swordGained)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ShootLeft(doublePUGained);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ShootRight(doublePUGained);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ShootUP(doublePUGained);
            }           
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ShootDown(doublePUGained);
            }          
        }

    }

    public void ShootUP(bool doublePU) 
    {
        swordAudioSource.Play();
        if (doublePU)
        {
            Vector3 pos1 = firePoint.position - (new Vector3(0.5f, 0f, 0f));
            Vector3 pos2 = firePoint.position - (new Vector3(-0.5f, 0f, 0f));

            Instantiate(bulletPrefab, pos1, Quaternion.Euler(0f, 0f, 90f));
            Instantiate(bulletPrefab, pos2, Quaternion.Euler(0f, 0f, 90f));
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, 90f));
        }
    }
    public void ShootDown(bool doublePU) 
    {
        swordAudioSource.Play();
        if (doublePU)
        {
            Vector3 pos1 = firePoint.position - (new Vector3(0.5f, 0f, 0f));
            Vector3 pos2 = firePoint.position - (new Vector3(-0.5f, 0f, 0f));

            Instantiate(bulletPrefab, pos1, Quaternion.Euler(0f, 0f, -90f));
            Instantiate(bulletPrefab, pos2, Quaternion.Euler(0f, 0f, -90f));
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, -90f));
        }
    }
    public void ShootLeft(bool doublePU) 
    {
        swordAudioSource.Play();
        if (doublePU)
        {
            Vector3 pos1 = firePoint.position - (new Vector3(0f, 0.5f, 0f));
            Vector3 pos2 = firePoint.position - (new Vector3(0f, -0.5f, 0f));

            Instantiate(bulletPrefab, pos1, Quaternion.Euler(0f, 0f, 180f));
            Instantiate(bulletPrefab, pos2, Quaternion.Euler(0f, 0f, 180f));
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, 180f));
        }
    }
    public void ShootRight(bool doublePU) 
    {
        swordAudioSource.Play();
        if (doublePU)
        {
            Vector3 pos1 = firePoint.position - (new Vector3(0f, 0.5f, 0f));
            Vector3 pos2 = firePoint.position - (new Vector3(0f, -0.5f, 0f));

            Instantiate(bulletPrefab, pos1, Quaternion.Euler(0f, 0f, 0f));
            Instantiate(bulletPrefab, pos2, Quaternion.Euler(0f, 0f, 0f));
        }
        else
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0f, 0f, 0f));
        }
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

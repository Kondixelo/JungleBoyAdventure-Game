using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_death_script : MonoBehaviour
{
    public AudioSource EnemyHitAudioSource;
    void Start()
    {
        EnemyHitAudioSource.Play();
        Invoke("DestroyDeadSlime", 3f);
    }

   public void DestroyDeadSlime()
    {
        Destroy(gameObject);
    }
}

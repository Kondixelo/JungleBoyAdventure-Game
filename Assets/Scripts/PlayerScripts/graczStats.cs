using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graczStats : MonoBehaviour
{
    [SerializeField] GameObject player;
    public int maxHP;
    public float movementSpeed;
    public float forceJump;
    public int extraJumps;

    public int StatsHealth()
    {
        return maxHP;
    }
    public float StatsMovementSpeed()
    {
        return movementSpeed;
    }

    public float StatsJumpForce()
    {
        return forceJump;
    }

    public int StatsExtraJumps()
    {
        return extraJumps;
    }

}

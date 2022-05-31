using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating_object : MonoBehaviour
{
    private float floatingVelocity;
    private bool moveUP;
    void Start()
    {
        floatingVelocity = 0.1f;
        moveUP = true;
    }

    void Update()
    { 
        if (moveUP == true)
        {
            floatingVelocity += 0.001f;
        }
        if (moveUP == false)
        {
            floatingVelocity -= 0.001f;
        }     

        if (floatingVelocity < -0.25f)
        {
            moveUP = true;
        }
        if (floatingVelocity > 0.25f)
        {
            moveUP = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, floatingVelocity);
    }
}

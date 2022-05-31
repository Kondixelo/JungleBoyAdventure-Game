using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  pivotText: MonoBehaviour
{
    private bool toTheRight = true;

    void Update()
    {
        var movementHor = Input.GetAxis("Horizontal");
        if (movementHor != 0)
        {
            if (movementHor > 0 && !toTheRight)
            {
                Flip();
            }
            else if (movementHor < 0 && toTheRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        toTheRight = !toTheRight;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        this.transform.localScale = Scaler;

    }
}

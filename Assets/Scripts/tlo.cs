using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tlo : MonoBehaviour
{
    private bool wPrawo = true;
    public GameObject player;

    void Update()
    {
        /*
        var movementHor = Input.GetAxis("Horizontal");
        if (movementHor > 0 && !wPrawo)
        {
            Flip();
        }
        else if (movementHor < 0 && wPrawo)
        {
            Flip();
        }
        */
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }

    void Flip()
    {
        wPrawo = !wPrawo;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

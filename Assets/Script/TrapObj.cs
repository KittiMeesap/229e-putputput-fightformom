using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TrapObj : MonoBehaviour
{
    int decayAmount = 25;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            FindObjectOfType<HealthBar>().LoseHealth(decayAmount);
            FindObjectOfType<LifeCount>().LoseLife();
        }
    }

}

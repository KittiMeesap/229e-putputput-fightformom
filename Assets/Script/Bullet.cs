using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        if (collision.GetComponent<ShootingAction>())
            collision.GetComponent<ShootingAction>().Action();

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
    public float spd;

    private void Update()
    {
        //bullet move
        transform.Translate(transform.right * transform.localScale.x * spd * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        if (collision.GetComponent<ShootingAction>())
           collision.GetComponent<ShootingAction>().Action();
        //Destory
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public Transform shootingPoint;
    public bool canShoot = true;
    public float shootForce = 20f;
    public float downForce = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
        }
    }

    void Shoot()
    {
        if (!canShoot)
            return;

        GameObject bullet = Instantiate(Bullet, shootingPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 shootDirection = (Vector2)shootingPoint.transform.right * shootForce;
        rb.AddForce(shootDirection, ForceMode2D.Impulse);
        rb.AddForce(Vector2.down * downForce, ForceMode2D.Impulse); // Add upward force

        //GameObject si = Instantiate(Bullet,shootingPoint);
        //si.transform.parent = null;
    }
}

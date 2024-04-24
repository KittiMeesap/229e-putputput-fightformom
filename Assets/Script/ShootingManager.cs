using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPoint;
    public bool canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!canShoot)
            return;

        GameObject bu = Instantiate(bullet,shootingPoint);
        bu.transform.parent = null;
    }
}

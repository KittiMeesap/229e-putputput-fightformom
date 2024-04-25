using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject shootingItem;
    public Transform shootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        if (!canShoot)
            return;

        GameObject si = Instantiate(shootingItem, shootingPoint);
        si.transform.parent = null;
    }

}

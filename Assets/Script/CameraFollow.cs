using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;
    public Vector3 minValuse, maxValue;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;

        Vector3 boundPosition = new Vector3(Mathf.Clamp(targetPosition.x,minValuse.x, maxValue.x), Mathf.Clamp(targetPosition.y, minValuse.y, maxValue.y), Mathf.Clamp(targetPosition.z, minValuse.z, maxValue.z));

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = targetPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        if (collision.GetComponent<ShootingAction>())
            collision.GetComponent<ShootingAction>().Action();

        Destroy(gameObject);
    }
}

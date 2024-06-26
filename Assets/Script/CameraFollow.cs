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

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);

        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(smoothedPosition.x, minValuse.x, maxValue.x),
            Mathf.Clamp(smoothedPosition.y, minValuse.y, maxValue.y),
            Mathf.Clamp(smoothedPosition.z, minValuse.z, maxValue.z)
        );

        transform.position = clampedPosition;
    }
}

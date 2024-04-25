using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Parameters")]
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayber;
    public GameObject detectedObj;
    [Header("Others")]
    public List<GameObject> pickedItems = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (DetectObj())
        {
            if (InteractInput())
            {
                detectedObj.GetComponent<Item>().Interact();
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObj()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position,detectionRadius,detectionLayber);

        if (obj == null )
        {
            detectedObj = null;
             return false;
        }else
        {
            detectedObj = obj.gameObject;
            return true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    public void PickUpItems(GameObject item)
    {
        pickedItems.Add(item);    
    }

}

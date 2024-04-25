using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType
    {
        NONE,
        PickUp,
        Examine
    }

    public InteractionType type;

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                break;
                
            case InteractionType.Examine:
                break;

            default:
                break;
        }
    }
}

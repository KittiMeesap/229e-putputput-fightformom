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

    [Header("Examine")]
    public string descriptionText;
    public Sprite image;

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
                FindObjectOfType<InteractionSystem>().PickUpItems(gameObject);
                gameObject.SetActive(false);
                break;
                
            case InteractionType.Examine:
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                break;

            default:
                break;
        }
    }
}

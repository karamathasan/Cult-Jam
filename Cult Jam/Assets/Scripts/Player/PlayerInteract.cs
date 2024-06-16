using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    internal Player player;
    [SerializeField]
    public List<Key> keys;
    public List<int> keyIDs;
    public Throwable heldThrowable;// the player can only hold on to one throwable at a time

    private void Update()
    {
        Interaction();
        ThrowItem();
    }
    void Interaction()
    {
        if (player.input.interact())
        {
            Interactable[] interactables = FindObjectsOfType<Interactable>();
            Interactable closest = interactables[0];
            float minDist = float.MaxValue;
            foreach (Interactable e in interactables)
            {
                float currentDist = Vector2.Distance(transform.position, e.getPosition());
                if (currentDist < minDist)
                {
                    minDist = currentDist;
                    closest = e;
                }
            }
            if (closest.inRange(transform.position))
            {
                closest.interact();
            }
        }
    }

    void ThrowItem()
    {
        if (player.input.throwItem() && heldThrowable != null)
        {
            heldThrowable.Throw();
            heldThrowable = null;
        }
    }
}

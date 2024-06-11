using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    internal Player player;
    [SerializeField]
    float detectionRadius = 1;

    private void Update()
    {
        Interaction();
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
                float currentDist = Vector2.Distance(transform.position, e.transform.position);
                if (currentDist < minDist)
                {
                    minDist = currentDist;
                    closest = e;
                }
            }
            if (minDist < detectionRadius)
            {
                closest.interact();
            }
        }
        
    }
}

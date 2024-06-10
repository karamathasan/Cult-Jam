using System.Collections;
using System.Collections.Generic;
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
            Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position, detectionRadius);
            foreach(Collider2D col in cols)
            {
                if(col.TryGetComponent(out Interactable interactable))
                {
                    interactable.interact();
                }
            }
        }
        
    }
}

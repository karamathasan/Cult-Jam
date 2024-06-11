using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected float detectionRadius = 1;
    public abstract void interact();

    public bool inRange()
    {
        return Physics2D.OverlapCircle(transform.position, 1).TryGetComponent(out Player p);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //protected float detectionRadius;
    protected float detectionRadius = 1;
    public abstract void interact();
    public virtual Vector2 getPosition()
    {
        return transform.position;
    }

    public bool inRange(Vector2 position)
    {
        return Vector2.Distance(position, getPosition()) < detectionRadius;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Throwable : Interactable
{
    public abstract override void interact();

    public abstract void Throw();
}

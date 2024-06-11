using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : Interactable
{
    public override void interact()
    {
        Debug.Log("Evidence Collected");
        Destroy(gameObject);
    }   
}

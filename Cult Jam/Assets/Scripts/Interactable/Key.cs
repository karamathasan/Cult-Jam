using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    [SerializeField]
    int keyID;

    public override void interact()
    {
        PlayerInteract I = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        I.keys.Add(this);
        I.keyIDs.Add(keyID);
        Destroy(gameObject);
    }
}

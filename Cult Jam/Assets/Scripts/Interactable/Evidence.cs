using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : Interactable
{
    public override void interact()
    {
        PlayerStats s = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        s.EvidenceFound();
        //Debug.Log("Evidence Collected");
        Destroy(gameObject);
    }   
}

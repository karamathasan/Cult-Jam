using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : Interactable
{
    public static int TotalEvidence = 0;
    public int ID;
    void Start()
    {
        TotalEvidence++;
    }
    public override void interact()
    {
        PlayerStats s = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        s.EvidenceFound(ID);
        Destroy(gameObject);
    }   
}

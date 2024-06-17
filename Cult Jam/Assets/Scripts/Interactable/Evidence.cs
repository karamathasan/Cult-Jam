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
        s.player.speech.speak("Got one, " + (TotalEvidence - s.collectedEvidenceIDs.Count) + " left");
        s.EvidenceFound(ID);
        Destroy(gameObject);
    }   
}

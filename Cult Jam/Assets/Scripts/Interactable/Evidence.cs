using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : Interactable
{
    public static int TotalEvidence = 0;
    public int ID;
    public string[] message;

    void Start()
    {
        TotalEvidence++;
    }

    public override void interact()
    {
        PlayerStats s = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        s.EvidenceFound(ID);
        //s.player.speech.speak("Got one, " + (TotalEvidence - s.collectedEvidenceIDs.Count) + " left");

        List<string> sentences = new List<string>();
        sentences.Add("Got one, " + (TotalEvidence - s.collectedEvidenceIDs.Count) + " left");
        foreach (string sentence in message)
        {
            sentences.Add(sentence);
        }
        s.player.speech.speak(sentences.ToArray());
        Destroy(gameObject);
    }
}

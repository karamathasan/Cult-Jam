using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapExit : Interactable
{
    public override void interact()
    {
        PlayerStats s = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        if (s.isEvidenceFound)
        {
            Debug.Log("Exit");
            //Scene transition
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapExit : Interactable
{
    public void Start()
    {
        detectionRadius = 2f;
    }

    public override void interact()
    {
        //PlayerStats s = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        SceneTransitioner.Instance.PlayNext();
    }
}

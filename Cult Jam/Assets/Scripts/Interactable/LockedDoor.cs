using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door
{
    [SerializeField]
    int doorID;
    bool doorOpen = false;
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        WorldSound sound = new WorldSound(transform.position, 5);
    }

    public override void interact()
    {
        PlayerInteract I = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteract>();
        if (I.keyIDs.Contains(doorID) && !doorOpen)
        {
            Debug.Log(name + " opened");
            TileCollider.enabled = !(TileCollider.enabled);
            tr.enabled = !tr.enabled;
            doorOpen = true;
            WorldSound sound = new WorldSound(transform.position, 25);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : Interactable
{
    [SerializeField]
    protected TilemapCollider2D TileCollider;
    [SerializeField]
    protected TilemapRenderer tr;

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        PlayerInput input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        if (input.shift())
        {
            OpenDoor();
            WorldSound sound = new WorldSound(transform.position, 35);
        }
        else if (!input.ctrl())
        {
            WorldSound sound = new WorldSound(transform.position, 7);
        }
    }

    public override void interact()
    {
        OpenDoor();
        WorldSound sound = new WorldSound(transform.position, 25);
    }

    public void OpenDoor()
    {
        Debug.Log(name + " opened");
        TileCollider.enabled = !(TileCollider.enabled);
        tr.enabled = !tr.enabled;
    }
}

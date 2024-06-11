using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : Interactable
{
    [SerializeField]
    TilemapCollider2D TileCollider;
    [SerializeField]
    TilemapRenderer tr;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement mov = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (mov.rb.velocity.magnitude > mov.runSpeed - 1)
        {
            interact();
        }
    }

    public override void interact()
    {
        Debug.Log(name + " opened");
        TileCollider.enabled = !(TileCollider.enabled);
        tr.enabled = !tr.enabled;
        WorldSound sound = new WorldSound(transform.position, 25);
    }
}

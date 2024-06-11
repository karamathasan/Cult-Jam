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

    public override void interact()
    {
        Debug.Log("interaction");
        TileCollider.enabled = !(TileCollider.enabled);
        tr.enabled = !tr.enabled;
    }
}

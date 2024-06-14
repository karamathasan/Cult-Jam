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
        PlayerInput input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        if (input.shift())
        {
            OpenDoor();
            WorldSound sound = new WorldSound(transform.position, 35);
        }
        else if (!input.ctrl())
        {
            //bumping into the door makes noise
            WorldSound sound = new WorldSound(transform.position, 7);
        }
    }

    public override void interact()
    {
        PlayerInput input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        if (input.ctrl())
        {
            StartCoroutine(DelayOpen(1.25f));
            WorldSound sound = new WorldSound(transform.position, 2);
        }
        else
        {
            StartCoroutine(DelayOpen(0.5f));
            new WorldSound(transform.position, 12);
        }
    }

    public void OpenDoor()
    {
        Debug.Log(name + " opened");
        TileCollider.enabled = !(TileCollider.enabled);
        tr.enabled = !tr.enabled;
    }

    IEnumerator DelayOpen(float delay)
    {
        yield return new WaitForSeconds(delay);
        TileCollider.enabled = !(TileCollider.enabled);
        tr.enabled = !tr.enabled;
    }
}

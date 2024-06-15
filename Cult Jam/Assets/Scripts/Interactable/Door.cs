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
    [SerializeField]
    protected DoorSounds sounds;

    private void Start()
    {
        detectionRadius = 2.5f;
    }


    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInput input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        if (input.shift())
        {
            OpenDoor();
            WorldSound sound = new WorldSound(transform.position, 35);
            SoundManager.instance.playSound(sounds.getRandomDoorSlam(), transform.position, 1);
        }
        else if (!input.ctrl())
        {
            //bumping into the door makes noise
            WorldSound sound = new WorldSound(transform.position, 7);
            SoundManager.instance.playSound(sounds.getRandomDoorBump(), transform.position, 1);
        }
    }

    public override void interact()
    {
        PlayerInput input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        if (input.ctrl())
        {
            SoundManager.instance.playSound(sounds.getRandomDoorOpenSoft(), transform.position, 1);
            StartCoroutine(DelayOpen(1.25f));
            WorldSound sound = new WorldSound(transform.position, 2);

        }
        else
        {
            SoundManager.instance.playSound(sounds.getRandomDoorOpen(), transform.position, 1);
            StartCoroutine(DelayOpen(0.5f));
            new WorldSound(transform.position, 12);
        }
    }

    public void OpenDoor()
    {
        TileCollider.enabled = !(TileCollider.enabled);
        tr.enabled = !tr.enabled;
    }

    public IEnumerator DelayOpen(float delay)
    {
        yield return new WaitForSeconds(delay);
        TileCollider.enabled = !(TileCollider.enabled);
        tr.enabled = !tr.enabled;
    }

    public override Vector2 getPosition()
    {
        return (Vector2)transform.position + new Vector2(0, 1.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door
{
    [SerializeField]
    int doorID;
    bool doorOpen = false;
    bool doorLocked = true;
    [SerializeField]
    SpriteRenderer doorLockedIndicator;

    private void Start()
    {
        detectionRadius = 2.5f;
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInput input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();

        if (doorLocked)
        {
            if (input.shift())
            {
                new WorldSound(transform.position, 25);
                SoundManager.instance.playSound(sounds.getRandomDoorSlam(), transform.position, 1);
            }
            else if (!input.ctrl())
            {
                //bumping into the door makes noise
                new WorldSound(transform.position, 7);
                SoundManager.instance.playSound(sounds.getRandomDoorBump(), transform.position, 1);
            }
        }
        else
        {
            if (input.shift())
            {
                OpenDoor();
                new WorldSound(transform.position, 35);
                SoundManager.instance.playSound(sounds.getRandomDoorSlam(), transform.position, 1);
            }
            else if (!input.ctrl())
            {
                //bumping into the door makes noise
                new WorldSound(transform.position, 7);
                SoundManager.instance.playSound(sounds.getRandomDoorBump(), transform.position, 1);
            }
        }
    }

    public override void interact()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerInput input = player.input;
        PlayerInteract interactor = player.interactor;
        if (!doorLocked)
        {
            if (input.ctrl())
            {
                SoundManager.instance.playSound(sounds.getRandomDoorOpenSoft(), transform.position, 1);
                StartCoroutine(DelayOpen(1.25f));
                new WorldSound(transform.position, 2);

            }
            else
            {
                SoundManager.instance.playSound(sounds.getRandomDoorOpen(), transform.position, 1);
                StartCoroutine(DelayOpen(0.5f));
                new WorldSound(transform.position, 12);
            }
        }
        else if (!(interactor.keyIDs.Contains(doorID) && !doorOpen))
        {
            //SoundManager.instance.playSound(sounds.getRandomDoorLocked())
            player.speech.speak("It's locked, I need the key");
            // add locked door sounds here
        }
        
        if (interactor.keyIDs.Contains(doorID) && !doorOpen && doorLocked)
        {
            Unlock();
        }
    }

    public void Unlock()
    {
        doorLocked = false;
        doorLockedIndicator.color = new Color(0, 0, 0, 0);
    }
}

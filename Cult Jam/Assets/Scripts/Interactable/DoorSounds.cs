using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSounds : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    AudioClip[] DoorSlam;
    [SerializeField]
    AudioClip[] DoorOpenSoft;
    [SerializeField]
    AudioClip[] DoorOpen;
    [SerializeField]
    AudioClip[] DoorBump;
    [SerializeField]
    AudioClip[] DoorClose;

    public AudioClip getRandomDoorSlam()
    {
        return DoorSlam[Random.Range(0, DoorSlam.Length)];
    }

    public AudioClip getRandomDoorOpenSoft()
    {
        return DoorOpenSoft[Random.Range(0, DoorOpenSoft.Length)];
    }

    public AudioClip getRandomDoorOpen()
    {
        return DoorOpen[Random.Range(0, DoorOpen.Length)];
    }

    public AudioClip getRandomDoorBump()
    {
        return DoorBump[Random.Range(0, DoorBump.Length)];
    }

    public AudioClip getRandomDoorClose()
    {
        return DoorClose[Random.Range(0, DoorClose.Length)];
    }

}

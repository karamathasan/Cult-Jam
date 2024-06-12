using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    internal Player player;
    [SerializeField]
    internal AudioClip[] audios;

    public AudioClip getRandomWalkAudio()
    {
        return audios[Random.Range(0, 8)];
    }

    public AudioClip getRandomRunAudio()
    {
        return audios[Random.Range(8, 16)];
    }

}

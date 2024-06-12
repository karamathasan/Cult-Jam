using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemySounds : MonoBehaviour
{
    [SerializeField]
    internal Enemy enemy;
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

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
    [SerializeField]
    internal AudioClip[] chase;
    [SerializeField]
    internal AudioClip[] heard;

    public AudioClip getRandomWalkAudio()
    {
        return audios[Random.Range(0, 8)];
    }

    public AudioClip getRandomRunAudio()
    {
        return audios[Random.Range(8, 16)];
    }

    public AudioClip getChaseAudio()
    {
        return chase[Random.Range(0, chase.Length)];
    }

    public AudioClip getHeardAudio()
    {
        return heard[Random.Range(0, heard.Length)];
    }
}

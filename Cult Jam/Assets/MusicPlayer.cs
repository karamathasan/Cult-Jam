using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip music;
    void Awake()
    {
        //Debug.Log("Play music");
        //SoundManager.instance.playMusic(music);
    }
}

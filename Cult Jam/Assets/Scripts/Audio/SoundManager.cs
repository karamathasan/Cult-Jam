using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource SFX;
    [SerializeField]
    private AudioClip music;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }

    private void Start()
    {
        playMusic(music);
    }

    public void playSound(AudioClip clip, Vector2 position, float volume)
    {
        AudioSource source = Instantiate(SFX, position, Quaternion.identity);
        source.clip = clip;
        source.volume = volume;
        source.spatialBlend = 1;
        float length = source.clip.length;
        source.Play();
        Destroy(source.gameObject, length);
    }

    public void playSound2D(AudioClip clip, float volume)
    {
        AudioSource source = Instantiate(SFX, Vector2.zero, Quaternion.identity);
        source.clip = clip;
        source.volume = volume;
        source.spatialBlend = 0;
        float length = source.clip.length;
        source.Play();
        Destroy(source.gameObject, length);
    }

    public void playMusic(AudioClip music)
    {
        AudioSource source = Instantiate(SFX, Vector2.zero, Quaternion.identity);
        source.clip = music;
        source.volume = 0.15f;
        source.spatialBlend = 0;
        source.loop = true;
        source.Play();
    }
}

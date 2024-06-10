using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource SFX;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }

    void playSound(AudioClip clip, Transform soundTransform, float volume)
    {
        AudioSource source = Instantiate(SFX, soundTransform);
        source.clip = clip;
        source.volume = volume;
        source.spatialBlend = 1;
        float length = source.clip.length;
        source.Play();
        Destroy(source, length);

    }
}

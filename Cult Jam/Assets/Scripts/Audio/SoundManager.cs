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
}

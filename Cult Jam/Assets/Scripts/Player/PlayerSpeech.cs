using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeech : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    void speak(string speech)
    {
        Debug.Log(speech);
    }
}

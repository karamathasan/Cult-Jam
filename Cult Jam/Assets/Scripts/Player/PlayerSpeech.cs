using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeech : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    public void speak(string speech)
    {
        Debug.Log(speech);
    }
}

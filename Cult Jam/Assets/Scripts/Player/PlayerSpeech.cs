using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSpeech : MonoBehaviour
{
    [SerializeField]
    internal Player player;
    [SerializeField]
    internal TMP_Text text;

    private void Start()
    {
        text.text = "";
    }
    public void speak(string speech)
    {
        if (speech == "" || speech == null)
        {
            Debug.Log("Speech was null");
            return;
        }
        text.text = speech;
        StartCoroutine(clearText());
    }

    IEnumerator clearText()
    {
        yield return new WaitForSeconds(1.5f);
        text.text = "";
    }
}

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

    public void speak(string[] sentences)
    {
        StartCoroutine(speakSentences(sentences));
    }

    IEnumerator speakSentences(string[] sentences)
    {
        for (int i = 0; i < sentences.Length; i++)
        {
            if (!(sentences[i] == "" || sentences[i] == null))
            {
                text.text = sentences[i];
                yield return new WaitForSeconds(1.5f);
                text.text = "";
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator clearText()
    {
        yield return new WaitForSeconds(1.5f);
        text.text = "";
    }
}

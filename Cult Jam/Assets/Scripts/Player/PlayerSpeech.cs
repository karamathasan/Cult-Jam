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
        text.text = speech;
        StartCoroutine(clearText());
        //Debug.Log(speech);
    }

    IEnumerator clearText()
    {
        yield return new WaitForSeconds(1.5f);
        text.text = "";
    }
}

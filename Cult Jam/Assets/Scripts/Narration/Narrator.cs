using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Narrator : MonoBehaviour
{
    public NarrativeEntry[] entries;
    private NarrativeEntry currentEntry;
    public TMP_Text headerText;
    public TMP_Text bodyText;
    public float typingSpeed = 0.02f;
    private int entryIndex = 0;
    bool typingComplete = false;
    private void Start()
    {
        headerText.text = "";
        bodyText.text = "";
        currentEntry = entries[entryIndex];
        StartCoroutine(TypeEntry());
    }

    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            typingComplete = true;
        }

        if ((Input.GetKeyDown("space") || Input.GetMouseButton((int)MouseButton.Left) || Input.GetKeyDown(KeyCode.Return)) && typingComplete)
        {
            clearText();
            entryIndex++;
            if (entryIndex < entries.Length)
            {
                currentEntry = entries[entryIndex];
                StartCoroutine(TypeEntry());
            }
            else
            {
                SceneTransitioner.Instance.PlayNext();
            }
        }

    }

    void clearText()
    {
        headerText.text = "";
        bodyText.text = "";
    }


    IEnumerator TypeEntry()
    {
        typingComplete = false;
        foreach(char c in currentEntry.getHeader().ToCharArray())
        {
            headerText.text += c;
            //SoundManager.instance.playSound();
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(0.4f);
        foreach(char c in currentEntry.getBody().ToCharArray())
        {
            bodyText.text += c;
            //SoundManager.instance.playSound();

            yield return new WaitForSeconds(typingSpeed);
        }
        typingComplete = true;
    }

    IEnumerator FadeOut()
    {
        float alpha = 1;
        while(alpha > 0)
        {
            alpha -= 0.1f;
            headerText.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(0.02f);
        }
    }
}

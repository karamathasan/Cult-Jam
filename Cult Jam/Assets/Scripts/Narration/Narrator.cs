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
    public GameObject continueText;
    public float typingSpeed = 0.75f;
    private int entryIndex = 0;
    bool typingComplete = false;
    [SerializeField]
    AudioClip[] typewriter;

    private void Start()
    {
        headerText.text = "";
        bodyText.text = "";
        currentEntry = entries[entryIndex];
        StartCoroutine(TypeEntry());
    }

    private void Update()
    {
        if ((Input.GetKey("space") || Input.GetMouseButton((int)MouseButton.Left)) && !typingComplete)
        {
            typingSpeed = 0.02f;
        }
        else typingSpeed = 0.075f;

        if ((Input.GetKeyDown("space") || Input.GetMouseButtonDown((int)MouseButton.Left)) && typingComplete)
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
        continueText.SetActive(false);
        typingComplete = false;
        foreach(char c in currentEntry.getHeader().ToCharArray())
        {
            headerText.text += c;
            SoundManager.instance.playSound2D(getRandomTypeWriter(), 0.5f);
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(0.4f);
        foreach(char c in currentEntry.getBody().ToCharArray())
        {
            bodyText.text += c;

            SoundManager.instance.playSound2D(getRandomTypeWriter(), 0.5f);
            yield return new WaitForSeconds(typingSpeed);
        }
        if (SceneTransitioner.Instance.NextExits())
        {
            continueText.GetComponent<TMP_Text>().text = "END";
        }
        typingComplete = true;
        continueText.SetActive(true);
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

    AudioClip getRandomTypeWriter()
    {
        return typewriter[Random.Range(0, typewriter.Length)];
    }
}

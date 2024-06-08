using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSequencer : MonoBehaviour
{
    public static DialogueSequencer instance;
    public DialogueLine initLine;
    DialogueLine currentline;

    //public 

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
        currentline = initLine;
    }

    bool confirm()
    {
        return Input.GetKeyDown("space") || Input.GetKeyDown("e") || Input.GetMouseButtonDown((int)KeyCode.Mouse0);
    }

    private void Update()
    {

        if (confirm() && currentline.getNext() != null)
        {
            currentline = currentline.getNext();
        }
    }

    void displayText()
    {

    }

    //IEnumerator updateText()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //}
}

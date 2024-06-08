using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueLine : ScriptableObject
{
    public string Name;
    public string[] lines;
    DialogueLine next;

    public DialogueLine getNext()
    {
        return next;
    }
}

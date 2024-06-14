using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "new NarrativeEntry")]
public class NarrativeEntry : ScriptableObject
{
    [SerializeField]
    string month;
    [SerializeField]
    int day;
    [SerializeField]
    string hour;
    [SerializeField]
    string minute;
    [SerializeField]
    [TextArea(minLines:1,maxLines:5)]  
    string body;

    public string getHeader()
    {
        return "Ada S., " + (month + " " + day + ", ") + (hour + ":" + minute);
    }

    public string getBody()
    {
        return body;
    }
}

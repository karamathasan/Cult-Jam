using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "new NarrativeEntry")]
public class NarrativeEntry : ScriptableObject
{
    [SerializeField]
    protected string month;
    [SerializeField]
    protected int day;
    [SerializeField]
    protected string hour;
    [SerializeField]
    protected string minute;
    [SerializeField]
    [TextArea(minLines:1,maxLines:5)]
    protected string body;

    public virtual string getHeader()
    {
        return "Ada S., " + (month + " " + day + ", ") + (hour + ":" + minute);
    }

    public string getBody()
    {
        return body;
    }
}

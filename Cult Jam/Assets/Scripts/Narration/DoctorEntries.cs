using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Doctor Entry")]
public class DoctorEntries : NarrativeEntry
{
    public override string getHeader()
    {
        return "Zeke Haligman, " + (month + " " + day + ", ") + (hour + ":" + minute);
    }
}

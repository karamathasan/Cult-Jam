using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour, Interactable
{
    public void interact()
    {
        Debug.Log("Evidence Collected");
        Destroy(gameObject);
    }   
}

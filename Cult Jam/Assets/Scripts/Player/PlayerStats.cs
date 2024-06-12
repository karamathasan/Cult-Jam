using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    internal float health = 30;
    internal bool isEvidenceFound = false;

    public void EvidenceFound()
    {
        isEvidenceFound = true;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        //player.movement.rb.AddForce();
        if (health <= 0)
        {
            Debug.Log("Death");
        }
    }


}

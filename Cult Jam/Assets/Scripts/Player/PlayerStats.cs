using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    internal float health = 30;
    internal List<int> collectedEvidenceIDs = new List<int>();
    //internal GameObject gameOver;
    [SerializeField]
    internal GameOver gameOver;

    public void EvidenceFound(int ID)
    {
        collectedEvidenceIDs.Add(ID);
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        //player.movement.rb.AddForce();
        if (health <= 0)
        {
            player.anim.Die();
        }
    }
    public void Die()
    {
        Destroy(player.input);
        Destroy(player.movement);
        Destroy(player.interactor);
        Destroy(player.sounds);
        gameOver.gameObject.SetActive(true);
        
        //Destroy(player.stats);
    }

    internal bool isDead()
    {
        return (health <= 0);
    }


}

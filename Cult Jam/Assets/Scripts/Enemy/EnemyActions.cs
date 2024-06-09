using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    [SerializeField]
    internal Enemy enemy;
    [SerializeField]
    internal Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // attack player

    // chase player

    // pathfind to player

    // walk
    public void walk(Vector2 direction)
    {
        rb.velocity = enemy.stats.walkSpeed * direction;
    }

    public void walkToPoint(Vector2 pos)
    {
        Vector2.MoveTowards(transform.position, pos, enemy.stats.walkSpeed);
    }

    // sneak
    
}

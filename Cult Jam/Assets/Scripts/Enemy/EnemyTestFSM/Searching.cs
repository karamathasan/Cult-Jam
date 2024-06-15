using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Searching : State
{
    Vector2 lastSeen;
    Enemy enemy;
    float searchTimer;
    public Searching(Enemy enemy, Vector2 lastSeen)
    {
        this.lastSeen = lastSeen;
        this.enemy = enemy;
        name = "searching";
    }

    public override void Init()
    {
        Vector2 dir = (lastSeen - (Vector2)enemy.transform.position).normalized;
        Collider2D col = Physics2D.Raycast((Vector2)enemy.transform.position + dir, dir).collider;
        float dist = (col.transform.position - enemy.transform.position).magnitude;
        if (col.GetComponentInParent<TilemapCollider2D>() && dist < enemy.sensor.getDetectionDistance())//shows that theres a wall between where its trying to go
        {
            lastSeen = col.transform.position;
        }
        searchTimer = 5f;
    }

    public override void Execute()
    {
        //enemy.transform.right = 
        if (searchTimer > 0)
        {
            searchTimer -= Time.deltaTime;
        }
        enemy.actions.walkToPoint(lastSeen);
    }

    public override State Next()
    {
        if (enemy.sensor.playerInSight())
        {
            return new Chasing(enemy);
        }
        else if ((Vector2)enemy.transform.position == lastSeen)
        {
            return new Curious(enemy);
        }
        else if (searchTimer <= 0)
        {
            return new Patrolling(enemy);
        }
        else return null;
    }
}

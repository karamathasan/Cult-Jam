using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Searching : State
{
    Vector2 lastSeen;
    Enemy enemy;
    float timer;
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
    }

    public override void Execute()
    {
        //enemy.transform.right = 
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
        else return null;
    }
}

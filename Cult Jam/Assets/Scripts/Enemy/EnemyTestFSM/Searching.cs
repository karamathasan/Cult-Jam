using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Searching : State
{
    Vector2 lastSeen;
    Enemy enemy;
    public Searching(Enemy enemy, Vector2 lastSeen)
    {
        this.lastSeen = lastSeen;
        this.enemy = enemy;
    }

    public override void Init()
    {
    }
    public override void Execute()
    {
        enemy.actions.walkToPoint(lastSeen);
    }
    public override State Next()
    {
        if ((Vector2)enemy.transform.position == lastSeen)
        {
            return new Curious(enemy);
        }
        else return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    //[SerializeField]
    private Enemy enemy;
    private FiniteStateMachine fsm;    

    public Chasing(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public override void Init()
    {
        Debug.Log("Chasing Init");
    }

    public override void Execute()
    {
        enemy.actions.walk(enemy.sensor.directionToPlayer());
    }

    public override State Next()
    {
        if (enemy.sensor.distToPlayer() > 2f)
        {
            return new Patrolling(enemy);
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : State
{
    private FiniteStateMachine fsm;
    private Enemy enemy;
    public Patrolling(Enemy enemy)
    {
        this.enemy = enemy;
        fsm = enemy.fsm;
    }

    public override void Init()
    {
        Debug.Log("Patrolling Init");
    }

    public override void Execute()
    {
         
    }

    public override State Next()
    {
        if (enemy.sensor.distToPlayer() < 1)
        {
            return new Chasing(enemy);
        }
        else return null;
    }


}

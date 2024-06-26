using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    //[SerializeField]
    private Enemy enemy;
    private FiniteStateMachine fsm;
    //private bool beginChase = false;
    private float timer;
    private Vector2 lastSeen;

    public Chasing(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Init()
    {
        //Debug.Log("Chasing Init");
        timer = 0.5f;
    }

    public override void Execute()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        enemy.actions.run(enemy.sensor.directionToPlayer());
        //if ()
        lastSeen = enemy.sensor.getPlayerPosition();
    }

    public override State Next()
    {
        if (!enemy.sensor.playerInSight())
        {
            return new Searching(enemy, lastSeen);
        }
        return null;
    }
}

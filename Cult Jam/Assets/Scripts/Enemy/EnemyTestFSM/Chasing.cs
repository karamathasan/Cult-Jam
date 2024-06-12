using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : State
{
    //[SerializeField]
    private Enemy enemy;
    private FiniteStateMachine fsm;

    private float timer;
    private Vector2 lastSeen;

    public Chasing(Enemy enemy)
    {
        this.enemy = enemy;
        name = "chasing";
    }

    public override void Init()
    {
        timer = 0.5f;
        enemy.actions.StartCoroutine(enemy.sensor.exposePlayer());
    }

    public override void Execute()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        enemy.actions.run(enemy.sensor.directionToPlayer());
        if (enemy.sensor.distToPlayer() < 1.5f)
        {
            enemy.actions.attack();
        }
        if (enemy.sensor.playerInSight())
        {
            lastSeen = enemy.sensor.getPlayerPosition();
        }
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

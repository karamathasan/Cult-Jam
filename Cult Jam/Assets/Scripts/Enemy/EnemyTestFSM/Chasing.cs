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
    float stepTimer = 0;
    float stepPeriod = 0.1f;

    public Chasing(Enemy enemy)
    {
        this.enemy = enemy;
        name = "chasing";
    }

    public override void Init()
    {
        timer = 0.5f;
        enemy.actions.StartCoroutine(enemy.sensor.exposePlayer());
        SoundManager.instance.playSound(enemy.sounds.getChaseAudio(), enemy.transform.position, 15);

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
        updateTimer();
    }

    void updateTimer()
    {
        if (stepTimer > 0)
        {
            stepTimer -= Time.deltaTime;
        }
        if (stepTimer <= 0)
        {
            stepTimer = stepPeriod;
            SoundManager.instance.playSound(enemy.sounds.getRandomRunAudio(), enemy.transform.position, 10);
        }
    }

    public override State Next()
    {
        if (!enemy.sensor.playerInSight() && !enemy.sensor.getPlayer().stats.isDead())
        {
            return new Searching(enemy, lastSeen);
        }
        else if (enemy.sensor.getPlayer().stats.isDead())
        {
            return new Patrolling(enemy, enemy.fsm.cyclical);
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Curious : State
{
    Enemy enemy;
    FiniteStateMachine fsm;
    float memoryTimer;
    float startupTimer;
    
    public Curious(Enemy enemy) 
    {
        this.enemy = enemy;
        this.fsm = enemy.fsm;
        name = "curious";
    }

    public override void Init()
    {
        SoundManager.instance.playSound(enemy.sounds.getHeardAudio(), enemy.transform.position, 10);
        memoryTimer = 2.5f;
        startupTimer = 0.5f;
    }

    public override void Execute()
    {
        if (startupTimer > 0)
        {
            startupTimer -= Time.deltaTime;
            return;
        }
        if (memoryTimer > 0 && startupTimer <= 0)
        {
            memoryTimer -= Time.deltaTime;
        }
        if (enemy.sensor.latestSoundRemembered) 
        {
            enemy.actions.walkToPoint(enemy.sensor.latestSound);
        }
    }


    public override State Next()
    {
        if (enemy.sensor.playerInSight())
        {
            return new Chasing(enemy);
        }
        else if (memoryTimer <= 0)
        {
            return new Patrolling(enemy, enemy.fsm.cyclical);
        }
        else return null;
        
    }
}

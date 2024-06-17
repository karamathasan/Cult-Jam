using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : State
{
    private EnemyTestFSM fsm;
    private Enemy enemy;
    private Vector2[] waypoints;
    private int waypointIndex = 0;
    [SerializeField]
    public bool cyclical = true;
    float stepTimer = 0;
    float stepPeriod = 0.75f;
    
    public Patrolling(Enemy enemy, bool cyclical = true)
    {
        this.enemy = enemy;
        fsm = enemy.fsm;
        waypoints = fsm.wayPoints;
        this.cyclical = cyclical;
        name = "patrolling";
    }

    public override void Init()
    {
        if (waypoints.Length > 0)
        {
            enemy.transform.right = waypoints[waypointIndex] - (Vector2)enemy.transform.position;
        }
        if(waypoints.Length == 1)
        {
            enemy.actions.walkToPoint(waypoints[0]);
            enemy.transform.right = new Vector3(0, -90);
        }
        if (!cyclical && waypoints.Length > 0)
        {
            Vector2[] copy = (Vector2[])waypoints.Clone();
            waypoints = new Vector2[2 * copy.Length - 1];
            int direction = 1;
            int j = 0;
            for (int i = 0; i < waypoints.Length; i++)
            {
                if (!(i < copy.Length))
                {
                    direction = -1;
                }
                j += direction;
                waypoints[i] = copy[j];
            }
        }

    }

    public override void Execute()
    {
        if (waypoints.Length <= 1)
        {
            return;
        }

        enemy.actions.walkToPoint(waypoints[waypointIndex]);
        if ((Vector2)enemy.transform.position == waypoints[waypointIndex])
        {
            CycleThroughWaypoints();
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
            if (Vector2.Distance(enemy.sensor.getPlayerPosition(), enemy.transform.position) < 30)
            {
                SoundManager.instance.playSound(enemy.sounds.getRandomWalkAudio(), enemy.transform.position, 10);
            }
        }
    }

    void CycleThroughWaypoints()
    {
        waypointIndex++;
        waypointIndex = waypointIndex % waypoints.Length;
        enemy.transform.right = waypoints[waypointIndex] - (Vector2)enemy.transform.position;
    }

    public override State Next()
    {
        if (enemy.sensor.playerInSight())
        {
            return new Chasing(enemy);
        }
        else if (enemy.sensor.latestSoundRemembered)
        {
            return new Curious(enemy);
        }
        else return null;
    }
}

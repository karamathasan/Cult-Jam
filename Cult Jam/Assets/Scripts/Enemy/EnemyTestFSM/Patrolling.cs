using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : State
{
    private EnemyTestFSM fsm;
    private Enemy enemy;
    private Vector2[] waypoints;
    private int waypointIndex = 0;
    
    public Patrolling(Enemy enemy)
    {
        this.enemy = enemy;
        fsm = enemy.fsm;
        waypoints = fsm.wayPoints;
        name = "patrolling";
    }

    public override void Init()
    {
        enemy.transform.right = waypoints[waypointIndex] - (Vector2)enemy.transform.position;
    }

    public override void Execute()
    {
        enemy.actions.walkToPoint(waypoints[waypointIndex]);
        if ((Vector2)enemy.transform.position == waypoints[waypointIndex])
        {
            waypointIndex++;
            waypointIndex = waypointIndex % waypoints.Length;
            enemy.transform.right = waypoints[waypointIndex] - (Vector2)enemy.transform.position;
        }
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

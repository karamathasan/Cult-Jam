using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemySensor : MonoBehaviour
{
    [SerializeField]
    internal Enemy enemy;
    [SerializeField]
    internal Light2D light;
    //player heard

    //player seen
    public bool inSight()
    {
        float detectionDistance = 5;
        float halfFovDegrees = 30;
        float directionDiff = Vector2.Angle(transform.localEulerAngles, directionToPlayer());
        if (distToPlayer() < detectionDistance && directionDiff < halfFovDegrees)
        {
            return true;
        }
        return false;
    }

    //noise heard

    //distance to player
    public float distToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        return (transform.position - player.transform.position).magnitude;
    }

    // direction to player
    public Vector2 directionToPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        return (player.transform.position - transform.position).normalized;
    }

}

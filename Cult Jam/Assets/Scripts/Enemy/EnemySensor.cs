using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemySensor : MonoBehaviour
{
    [SerializeField]
    internal Enemy enemy;
    [SerializeField]
    internal Light2D Light;
    [SerializeField]
    float detectionDistance = 5;
    [SerializeField]
    float halfFovDegrees = 30;

    //player heard

    //player seen
    public bool inSight()
    {
        float directionDiff = Vector2.Angle(transform.localEulerAngles, directionToPlayer());
        if (distToPlayer() < detectionDistance && directionDiff < halfFovDegrees)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Vector2 pos = transform.position;
        Gizmos.DrawWireSphere(pos, detectionDistance);
        //Gizmos.DrawLine(pos, pos + );
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawLine(pos, pos + pos.normalized * detectionDistance);
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

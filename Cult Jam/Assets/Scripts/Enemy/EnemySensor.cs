using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemySensor : MonoBehaviour, WorldSoundListener
{
    [SerializeField]
    internal Enemy enemy;
    [SerializeField]
    internal Light2D Light;
    [SerializeField]
    float detectionDistance = 15;
    [SerializeField]
    float halfFovDegrees = 30;

    internal Vector2 latestSound;
    internal bool latestSoundRemembered;
    float latestSoundTimer;

    void Start()
    {
        Light.enabled = false;
    }

    void Update()
    {
        if (latestSoundTimer > 0)
        {
            latestSoundTimer -= Time.deltaTime;
        }
        if (latestSoundTimer < 0)
        {
            latestSoundRemembered = false;
        }
    }

    //player heard
    public void Respond(WorldSound sound)
    {
        latestSound = sound.getPosition();
        latestSoundRemembered = true;
        latestSoundTimer = 7;
    }

    //player seen
    public bool playerInSight()
    {
        float directionDiff = Vector2.Angle(transform.right, directionToPlayer());
        if (distToPlayer() < detectionDistance && directionDiff < halfFovDegrees)
        {
            Collider2D col = Physics2D.Raycast((Vector2)transform.position + directionToPlayer(), directionToPlayer()).collider;
            if(col.GetComponentInParent<Player>())
            {
                return true;
            }
        }
        return false;
    }

    public Vector2 getPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        return player.transform.position;
    }

    private void OnDrawGizmos()
    {
        Vector2 pos = transform.position;
        Gizmos.DrawWireSphere(pos, detectionDistance);
        //Gizmos.DrawLine(pos, pos + );
        //float directionDiff = Mathf.Deg2Rad * (transform.localEulerAngles.z - Mathf.Rad2Deg * (Mathf.Atan(directionToPlayer().y / directionToPlayer().x)));
        float directionDiff = Mathf.Deg2Rad * Vector2.SignedAngle(Vector2.right, directionToPlayer());
        float enemyAngle = Mathf.Deg2Rad * Vector2.SignedAngle(Vector2.right, transform.right);
        float upperBound = enemyAngle + Mathf.Deg2Rad * halfFovDegrees;
        float lowerBound = enemyAngle - Mathf.Deg2Rad * halfFovDegrees;
        
        Vector2 vec2player = new Vector2(Mathf.Cos(directionDiff), Mathf.Sin(directionDiff));
        Vector2 upperVec = new Vector2(Mathf.Cos(upperBound), Mathf.Sin(upperBound));
        Vector2 lowerVec = new Vector2(Mathf.Cos(lowerBound), Mathf.Sin(lowerBound));

        Gizmos.color = new Color(0, 1, 0);
        Gizmos.DrawLine(pos, pos + vec2player * detectionDistance);
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawLine(pos, pos + upperVec * detectionDistance);
        Gizmos.DrawLine(pos, pos + lowerVec * detectionDistance);
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

    public Player getPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public IEnumerator exposePlayer()
    {
        //Light.pointLightInnerAngle = halfFovDegrees;
        Light.pointLightOuterAngle = 2 * halfFovDegrees;
        Light.pointLightOuterRadius = 30;
        //Light.transform.right = -transform.right;
        Light.enabled = true;
        Light.intensity = 6;
        while (Light.intensity > 0)
        {
            yield return new WaitForSeconds(0.05f);
            Light.intensity -= 0.2f;
        }
        Light.enabled = false;
        //Light.transform.rotation = transform.rotation;
    }

    public float getDetectionDistance()
    {
        return detectionDistance;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    [SerializeField]
    internal Enemy enemy;
    [SerializeField]
    internal Rigidbody2D rb;
    [SerializeField]
    internal float accelerationConstant = 1.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // attack player
    public void attack()
    {
        if(Physics2D.OverlapCircle(transform.position, 2.25f).TryGetComponent(out PlayerStats s))
        {
            s.takeDamage(15);
        }
        
    }

    // chase player

    // pathfind to player

    // walk
    public void walk(Vector2 direction)
    {
        direction.Normalize();
        //rb.velocity = enemy.stats.walkSpeed * direction;
        Vector2 velocityError = direction * enemy.stats.walkSpeed - rb.velocity;
        rb.AddForce(accelerationConstant * velocityError);
    }

    public void run(Vector2 direction)
    {
        transform.right = ((Vector2)transform.right + direction)/2 ;
        direction.Normalize();
        Vector2 velocityError = direction * enemy.stats.runSpeed - rb.velocity;
        rb.AddForce(accelerationConstant * velocityError);
        AudioClip clip = enemy.sounds.getRandomRunAudio();
        if (Time.frameCount % (Application.targetFrameRate * 32) == 0)
        {
            SoundManager.instance.playSound(clip, transform, 10);
        }
    }

    public void walkToPoint(Vector2 pos)
    {
        float maxDelta = enemy.stats.walkSpeed * Time.deltaTime;
        enemy.transform.right = pos - (Vector2)enemy.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, pos, maxDelta);

        //Vector2 velocityError = (Vector2)enemy.transform.right * enemy.stats.walkSpeed - rb.velocity;
        //Vector2 positionError = pos - (Vector2)enemy.transform.position;
        //Vector2 force = Vector2.ClampMagnitude(positionError, velocityError.magnitude);
        //float dampingFactor = 0.2f;
        //Vector2 damp =  dampingFactor * positionError.normalized * 1/(positionError.magnitude + Mathf.Epsilon);

        //rb.AddForce(force - damp);

        AudioClip clip = enemy.sounds.getRandomWalkAudio();
        if(Time.frameCount % (Application.targetFrameRate * 128) == 0)
        {
            SoundManager.instance.playSound(clip, transform, 10);
        }
    }
}

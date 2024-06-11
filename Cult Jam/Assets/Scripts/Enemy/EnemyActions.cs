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
        direction.Normalize();
        Vector2 velocityError = direction * enemy.stats.runSpeed - rb.velocity;
        rb.AddForce(accelerationConstant * velocityError);
    }

    public void walkToPoint(Vector2 pos)
    {
        float maxDelta = enemy.stats.walkSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, pos, maxDelta);
        enemy.transform.right = pos - (Vector2)enemy.transform.position;

    }

    //public void 

    // sneak

}

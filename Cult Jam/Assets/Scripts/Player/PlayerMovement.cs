using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    internal Player player;
    internal Rigidbody2D rb;

    [SerializeField]
    internal float walkSpeed = 1;
    [SerializeField]
    internal float runSpeed = 2;
    [SerializeField]
    internal float sneakSpeed = 0.3f;
    float accelerationConstant = 2f;
    float walkTimer = 0;
    float walkPeriod = 0.5f;
    float runTimer = 0;
    float runPeriod = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player.input.shift())
        {
            Run();
            //return;
        }
        else if (player.input.ctrl())
        {
            Sneak();
            //return;
        }
        else
        {
            Walk();

        }
    }

    void Walk()
    {
        Vector2 direction = Vector2.zero;
        if (player.input.up())
        {
            direction += Vector2.up;
        }
        if (player.input.down())
        {
            direction += Vector2.down;
        }
        if (player.input.left())
        {
            direction += Vector2.left;
        }
        if (player.input.right())
        {
            direction += Vector2.right;
        }
        direction.Normalize();
        if (direction != Vector2.zero)
        {
            player.anim.playWalk(direction);
            player.worldSounds.Footsteps(6);
            if (walkTimer > 0)
            {
                walkTimer -= Time.deltaTime;
            }
            if (walkTimer <= 0)
            {
                walkTimer = walkPeriod;
                AudioClip clip = player.sounds.getRandomWalkAudio();
                SoundManager.instance.playSound2D(clip, 0.15f);
            }
        }


        Vector2 velocityError = walkSpeed * direction - rb.velocity;
        rb.AddForce(accelerationConstant * velocityError);
    }

    void Run()
    {
        Vector2 direction = Vector2.zero;
        if (player.input.up())
        {
            direction += Vector2.up;
        }
        if (player.input.down())
        {
            direction += Vector2.down;
        }
        if (player.input.left())
        {
            direction += Vector2.left;
        }
        if (player.input.right())
        {
            direction += Vector2.right;
        }
        direction.Normalize();
        if (direction != Vector2.zero) 
        {
            player.worldSounds.Footsteps(12);
            player.anim.playWalk(direction);
            if (runTimer > 0)
            {
                runTimer -= Time.deltaTime;
            }
            if (runTimer <= 0)
            {
                runTimer = runPeriod;
                AudioClip clip = player.sounds.getRandomWalkAudio();
                SoundManager.instance.playSound2D(clip, 0.15f);
            }
        }

        Vector2 velocityError = runSpeed * direction - rb.velocity;
        rb.AddForce( accelerationConstant * velocityError);


    }

    void Sneak()
    {
        Vector2 direction = Vector2.zero;
        if (player.input.up())
        {
            direction += Vector2.up;
        }
        if (player.input.down())
        {
            direction += Vector2.down;
        }
        if (player.input.left())
        {
            direction += Vector2.left;
        }
        if (player.input.right())
        {
            direction += Vector2.right;
        }
        direction.Normalize();
        if (direction != Vector2.zero)
        {
            player.worldSounds.Footsteps(1.5f);
            player.anim.playWalk(direction);//fix this later

        }

        Vector2 velocityError = sneakSpeed * direction - rb.velocity;
        rb.AddForce(velocityError);
    }


    public Vector2 getVelocity()
    {
        return (Vector2)rb.velocity;
    }

    public float HorizontalVelocity()
    {
        return getVelocity().x;
    }
    public float VerticalVelocity()
    {
        return getVelocity().y;
    }
    public Vector2 getInputDirection()
    {
        Vector2 direction = Vector2.zero;
        if (player.input.up())
        {
            direction += Vector2.up;
        }
        if (player.input.down())
        {
            direction += Vector2.down;
        }
        if (player.input.left())
        {
            direction += Vector2.left;
        }
        if (player.input.right())
        {
            direction += Vector2.right;
        }
        return direction;
    }



}

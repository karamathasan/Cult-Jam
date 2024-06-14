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
        else Walk();
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
            player.worldSounds.Footsteps(3);
            AudioClip clip = player.sounds.getRandomWalkAudio();
            if (Time.frameCount % (Application.targetFrameRate * 64) == 0)
            {
                SoundManager.instance.playSound(clip, transform.position, 0.1f);
            }
        }

        Vector2 velocityError = walkSpeed * direction - rb.velocity;
        rb.AddForce(velocityError);
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
            AudioClip clip = player.sounds.getRandomRunAudio();
            if (Time.frameCount % (Application.targetFrameRate * 48) == 0)
            {
                SoundManager.instance.playSound(clip, transform.position, 0.25f);
            }
        }

        Vector2 velocityError = runSpeed * direction - rb.velocity;
        rb.AddForce( 2 * velocityError);


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
        }

        Vector2 velocityError = sneakSpeed * direction - rb.velocity;
        rb.AddForce(velocityError);
    }
}

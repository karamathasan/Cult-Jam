using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    internal Animator anim;
    private string currentAnim;

    private void Update()
    {
        //playWalk();
        playIdle();
        //playSprint();
    }

    internal void playWalk(Vector2 input)
    {
        input.Normalize();
        if (Mathf.Abs(input.x) > 0)
        {
            if (input.x > 0)
            {
                anim.Play("WalkRight");
            }
            else if (input.x < 0)
            {
                anim.Play("WalkLeft");
            }
        }
        else if (Mathf.Abs(input.y) > 0)
        {
            if (input.y > 0)
            {
                anim.Play("WalkUp");
            }
            else if (input.y < 0)
            {
                anim.Play("WalkDown");
            }
        }
        //else anim.Play("Idle");
    }

    internal void playSprint()
    {
        float vx = player.movement.HorizontalVelocity();
        float vy = player.movement.VerticalVelocity();
        if (!player.input.shift())
        {
            return;
        }
        if (Mathf.Abs(vy) > Mathf.Abs(vx))
        {
            if (vy > 0)
            {
                anim.Play("WalkUp");
            }
            else anim.Play("WalkDown");
        }
        else
        {
            if (vx > 0)
            {
                anim.Play("WalkRight");
            }
            else
            {
                anim.Play("WalkLeft");
            }
        }
    }

    internal void playIdle()
    {
        if (player.movement.getInputDirection() == Vector2.zero)
        {
            anim.Play("Idle");
        }
    }

    internal void Die()
    {
        anim.Play("Death");
    }

    public void ChangeAnim(string newAnim)
    {
        if (currentAnim.Equals(newAnim))
        {
            return;
        }
        currentAnim = newAnim;
        anim.Play(newAnim);
    }

}

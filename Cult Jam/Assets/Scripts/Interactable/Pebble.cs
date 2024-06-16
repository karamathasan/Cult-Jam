using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : Throwable
{
    [SerializeField]
    float speed;
    [SerializeField]
    private Rigidbody2D rb;
    private bool thrown;
    public override void interact()
    {
        thrown = false;
        Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerInteract interactor = p.interactor;
        //the throwable might need to be a gameObj instead
        interactor.heldThrowable = this;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public override void Throw()
    {
        thrown = true;
        Player p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z
        Vector2 throwDirection = (mouseWorldPos - p.transform.position).normalized;

        transform.position = (Vector2)p.transform.position + throwDirection;
        rb.AddForce(throwDirection * speed, ForceMode2D.Impulse);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    void OnCollisionEnter2D()
    {
        if (thrown)
        {
            new WorldSound(transform.position, 15);
            thrown = false;
        }
    }
}

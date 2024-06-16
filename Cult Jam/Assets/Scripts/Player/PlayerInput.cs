using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    public bool left()
    {
        return Input.GetKey(KeyCode.A);
    }

    public bool right()
    {
        return Input.GetKey(KeyCode.D);
    }

    public bool down()
    {
        return Input.GetKey(KeyCode.S);
    }

    public bool up()
    {
        return Input.GetKey(KeyCode.W);
    }

    public bool shift()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    public bool ctrl()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }

    public bool interact()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool throwItem()
    {
        return Input.GetMouseButton(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldSounds : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    internal void Footsteps(float range)
    {
        WorldSound walking = new WorldSound(player.transform.position, range);
    }
}

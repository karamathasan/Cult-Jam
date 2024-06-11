using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    internal PlayerInput input;
    [SerializeField]
    internal PlayerMovement movement;
    [SerializeField]
    internal PlayerAnimator anim;
    [SerializeField]
    internal PlayerWorldSounds worldSounds;
    [SerializeField]
    internal PlayerInteract interactor;
    [SerializeField]
    internal PlayerStats stats;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    internal Enemy enemy;

    internal float walkSpeed = 1;
    internal float runSpeed = 6;
    internal float sneakSpeed = 0.5f;
    internal float health = 100;
}

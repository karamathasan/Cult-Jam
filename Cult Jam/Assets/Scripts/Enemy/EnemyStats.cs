using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    internal Enemy enemy;
    [SerializeField]
    internal float walkSpeed = 1;
    [SerializeField]
    internal float runSpeed = 7.75f;
    [SerializeField]
    internal float sneakSpeed = 0.5f;
    [SerializeField]
    internal float health = 100;
}

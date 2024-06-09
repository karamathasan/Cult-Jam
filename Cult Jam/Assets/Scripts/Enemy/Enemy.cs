using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    internal EnemySensor sensor;
    [SerializeField]
    internal EnemyTestFSM fsm;
    [SerializeField]
    internal EnemyActions actions;
    [SerializeField]
    internal EnemyStats stats;
}

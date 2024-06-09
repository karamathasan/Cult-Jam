using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestFSM : FiniteStateMachine
{
    [SerializeField]
    internal Enemy enemy;

    void Start()
    {
        initState = new Patrolling(enemy);
        currentState = initState;
        currentState.Init();
    }

    private void Update()
    {
        Evaluate();
    }

    public override void Evaluate()
    {
        currentState.Execute();
        if (currentState.Next() != null)
        {
            currentState = currentState.Next();
            currentState.Init();
        }
    }

    
}

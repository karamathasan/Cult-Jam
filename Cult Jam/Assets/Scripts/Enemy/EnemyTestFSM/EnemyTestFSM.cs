using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestFSM : FiniteStateMachine
{
    [SerializeField]
    internal Enemy enemy;
    [SerializeField]
    public Vector2[] wayPoints;
    [SerializeField]
    public bool cyclical = true;

    void Start()
    {
        initState = new Patrolling(enemy,cyclical);
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

    //private void OnGUI()
    //{
    //    GUILayout.Label(currentState.name);
    //}

    private void OnDrawGizmos()
    {
        foreach(Vector2 wp in wayPoints)
        {
            //Gizmos.DrawIcon(wp, "way point");
            Gizmos.color = new Color(0, 0.5f, 1);
            Gizmos.DrawSphere(wp, 0.2f); 
        }
    }

}

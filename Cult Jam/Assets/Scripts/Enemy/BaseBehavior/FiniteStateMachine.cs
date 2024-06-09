using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FiniteStateMachine : MonoBehaviour
{
    //public GameObject parent;
    protected State initState;
    protected State currentState;

    public abstract void Evaluate();

    public void setState(State newState)
    {
        currentState = newState;
    }

    public State getState()
    {
        return currentState;
    }
}

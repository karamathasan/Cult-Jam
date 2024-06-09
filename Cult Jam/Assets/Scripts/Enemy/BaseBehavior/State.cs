using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    FiniteStateMachine fsm;
    public abstract void Init();
    public abstract void Execute();
    public abstract State Next();
}

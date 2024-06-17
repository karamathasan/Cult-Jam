using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public string name;
    FiniteStateMachine fsm;
    public abstract void Init();

    public virtual void FixedExecute() { }
    public abstract void Execute();
    public abstract State Next();
}

using System;
using UnityEngine;

public abstract class AStateBehaviour : MonoBehaviour
{
    protected StateMachine AssociatedStateMachine;

    // Used To Find Components Etc And Makings sure it's all valid and good to go
    public abstract bool Initialize();

    public abstract void OnStateStart();
    public abstract void OnStateUpdate();
    public abstract void OnStateFinish();

    public abstract Type StateTransitionCondition();
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, AStateBehaviour> States = new Dictionary<Type, AStateBehaviour>();

    private AStateBehaviour CurrentState = null;
    
    private void Start()
    {
        AStateBehaviour[] AttachedStates = GetComponents<AStateBehaviour>();
        for (int i = 0; i < AttachedStates.Length; ++i)
        {
            States.Add(AttachedStates[i].GetType(), AttachedStates[i]);

            if (!AttachedStates[i].Initialize())
            {
                Debug.LogError($"StateMachine::Start - State {AttachedStates[i].GetType().FullName} Failed To Initialize");
                this.enabled = false;
            }
            
            // TODO: Editor Script
            if (i == 0)
            {
                CurrentState = AttachedStates[i];
            }
        }
    }

    private void Update()
    {
        if (CurrentState == null)
            return;
        
        CurrentState.OnStateUpdate();

        Type NextState = CurrentState.StateTransitionCondition();
        if (NextState != null)
        {
            SetState(NextState);
        }
    }
    

    public void SetState(Type StateToTransitionTo)
    {
        AStateBehaviour NewState = null;
        if (States.TryGetValue(StateToTransitionTo, out NewState))
        {
            CurrentState.OnStateFinish();
            NewState.OnStateStart();

            CurrentState = NewState;

            return;
        }
        
        Debug.LogError($"StateMachine::SetState - Failed To Set New State {StateToTransitionTo.FullName}");
    }
}

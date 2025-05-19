using System;
using System.Collections.Generic;
using UnityEngine;

// TODO: Possible Simple Alternative? https://github.com/SolidAlloy/ClassTypeReference-for-Unity
// State Machine Handler, This will initialize, and run the state that needs to run at a specific time
// TODO: Some sort of asset validation to ensure there aren't dupes etc
public class StateMachine : MonoBehaviour
{
    // Keeps Track Of What The First State Should Be
    // Custom Editor Hides This But Allows Us To Keep The Value Safely Stored in Memory
    [SerializeField] protected internal string InitialStateTypeName = "";
    [SerializeField] public string InitialStateTypeNameV2 = "";
    [SerializeField] protected bool SearchChildren = false;

    // Dictionary of state behaviours, this is an abstract class pointer, children use this template to implement the correct functions
    private Dictionary<Type, AStateBehaviour> StateBehaviours = new Dictionary<Type, AStateBehaviour>();

    // Tracks the currently running StateBehaviour
    private AStateBehaviour CurrentState = null;

    // Initialize The State machine As Well As Setup The Initial State
    private void Start()
    {
        if (!InitializeStates())
        {
            // Stop This class from executing
            this.enabled = false;
            return;
        }

        SetInitialState();
    }

    private bool InitializeStates()
    {
        AStateBehaviour[] StateBehaviourComponents = GetComponents<AStateBehaviour>();
        for (int i = 0; i < StateBehaviourComponents.Length; ++i)
        {
            AStateBehaviour BehaviourScript = StateBehaviourComponents[i];
            StateBehaviours.Add(BehaviourScript.GetType(), BehaviourScript);
        }

        if (SearchChildren)
        {
            AStateBehaviour[] StateBehaviourChildComponents = GetComponentsInChildren<AStateBehaviour>();
            for (int i = 0; i < StateBehaviourChildComponents.Length; ++i)
            {
                // Check If State Already Exists
                AStateBehaviour BehaviourScript = StateBehaviourChildComponents[i];
                StateBehaviours.Add(BehaviourScript.GetType(), BehaviourScript);
            } 
        }

        // Initializes all the states, if it fails then this turns off till the person configuring this fixes it
        foreach (KeyValuePair<Type, AStateBehaviour> KeyValueState in StateBehaviours)
        {
            AStateBehaviour CurrentBehaviour = KeyValueState.Value;
            if (CurrentBehaviour.InitializeState())
            {
                CurrentBehaviour.AssociatedStateMachine = this;
                continue;
            }
            
            Debug.Log($"StateMachine On {gameObject.name} has failed to initalize the state {CurrentBehaviour.GetType().Name}!");
            return false;
        }

        return true;
    }

    private void SetInitialState()
    {
        Type InitialTypeToSetup = Type.GetType(InitialStateTypeNameV2);

        if (IsValidNewStateIndex(InitialTypeToSetup))
        {
            CurrentState = StateBehaviours[InitialTypeToSetup];
            CurrentState.OnStateStart();
            
            Debug.Log("StartedState" + CurrentState.GetType().Name);
            return;
        }

        Debug.Log($"StateMachine On {gameObject.name} is has no state behaviours associated with it!");
    }

    // Update The State, and check if we can transition naturally rather than forced.
    void Update()
    {
        CurrentState.OnStateUpdate();

        Type newState = CurrentState.StateTransitionCondition();
        if (IsValidNewStateIndex(newState))
        {
            CurrentState.OnStateFinish();
            CurrentState = StateBehaviours[newState];
            CurrentState.OnStateStart();
        }
    }

    // Helper Function To See If States Are The Same, Unused atm
    public bool IsCurrentState(AStateBehaviour stateBehaviour)
    {
        return CurrentState == stateBehaviour;
    }

    // Helper Function to Force A New State
    public void SetState(Type StateKey)
    {
        if (IsValidNewStateIndex(StateKey))
        {
            CurrentState.OnStateFinish();
            CurrentState = StateBehaviours[StateKey];
            CurrentState.OnStateStart();
        }
    }

    // Ensure Index is Valid
    private bool IsValidNewStateIndex(Type StateKey)
    {
        if (StateKey == null)
            return false;
        
        return StateBehaviours.ContainsKey(StateKey);
    }

    // Gets The Current Running State
    public AStateBehaviour GetCurrentState()
    {
        return CurrentState;
    }
}


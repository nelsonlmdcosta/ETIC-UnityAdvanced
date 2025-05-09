using System;
using System.Collections;
using UnityEngine;

public class IdleState : AStateBehaviour
{
    private LineOfSight LineOfSightComponent = null;
    
    private Coroutine RunningRoutine = null;
    
    public override bool InitializeState()
    {
        LineOfSightComponent = GetComponent<LineOfSight>();
        
        return LineOfSightComponent != null;
    }

    public override void OnStateStart()
    {
        RunningRoutine = StartCoroutine(WaitForTimeAndContinuePatrolling());
    }

    public override void OnStateUpdate()
    {
        // Wait For Time?
    }

    public override void OnStateFinish()
    {
        if(RunningRoutine != null)
            StopCoroutine(RunningRoutine);
    }

    public override Type StateTransitionCondition()
    {
        if (LineOfSightComponent != null && LineOfSightComponent.HasSeenPlayerThisFrame())
            return typeof(ChasingState);
        
        return null;
    }

    private IEnumerator WaitForTimeAndContinuePatrolling()
    {
        yield return new WaitForSeconds(2.0f);

        AssociatedStateMachine.SetState(typeof(PatrolState));
    }
}

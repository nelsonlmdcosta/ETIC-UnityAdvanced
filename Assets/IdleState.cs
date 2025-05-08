using System;
using System.Collections;
using System.Threading;
using UnityEngine;

public class IdleState : AStateBehaviour
{
    public override bool Initialize()
    {
        return true;
    }

    public override void OnStateStart()
    {
        StartCoroutine(WaitForTimeAndContinuePatrolling());
    }

    public override void OnStateUpdate()
    {
        // Wait For Time?
    }

    public override void OnStateFinish()
    {
        
    }

    public override Type StateTransitionCondition()
    {
        return null;
    }

    private IEnumerator WaitForTimeAndContinuePatrolling()
    {
        yield return new WaitForSeconds(2.0f);

        AssociatedStateMachine.SetState(typeof(PatrolState));
    }
}

using System;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : AStateBehaviour
{
    private NavMeshAgent AIMover = null;

    private Vector3 Destination = Vector3.zero;
    
    public override bool Initialize()
    {
        AIMover = GetComponent<NavMeshAgent>();
        
        return AIMover != null; /*&& other component && soem other component*/
    }

    public override void OnStateStart()
    {
        AIMover.enabled = true;
        
        AIMover.SetDestination(Destination);
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateFinish()
    {
        AIMover.enabled = false;
    }

    public override Type StateTransitionCondition()
    {
        if (!AIMover.hasPath)
        {
            return typeof(IdleState);
        }

        return null;
    }
}

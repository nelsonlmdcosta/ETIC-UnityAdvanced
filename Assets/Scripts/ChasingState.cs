using System;
using UnityEngine;
using UnityEngine.AI;

public class ChasingState : AStateBehaviour
{
    private Transform Player;

    private NavMeshAgent AIMover;
    
    public override bool InitializeState()
    {
        Player = GameObject.FindWithTag("Player").transform;
        AIMover = GetComponent<NavMeshAgent>();
        
        return Player != null && AIMover != null;
    }

    public override void OnStateStart()
    {
        AIMover.enabled = true;

        AIMover.SetDestination(Player.position);
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateFinish()
    {
        
    }

    public override Type StateTransitionCondition()
    {
        if (AIMover && !AIMover.hasPath)
        {
            return typeof(IdleState);
        }

        return null;
    }
}

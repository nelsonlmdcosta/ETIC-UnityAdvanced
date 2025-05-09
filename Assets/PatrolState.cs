using System;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : AStateBehaviour
{
    [SerializeField] private POIManager PatrolPath = null;

    private LineOfSight LineOfSightComponent = null;
    private NavMeshAgent AIMover = null;
    private Vector3 Destination = Vector3.zero;

    private int POIIndex = 0;
    
    public override bool InitializeState()
    {
        AIMover = GetComponent<NavMeshAgent>();
        LineOfSightComponent = GetComponent<LineOfSight>();
        
        return AIMover != null && LineOfSightComponent != null && PatrolPath != null;
    }

    public override void OnStateStart()
    {
        AIMover.enabled = true;

        Destination = PatrolPath.GetPOIAtIndex(POIIndex++).position;
        if (!PatrolPath.IsIndexValid(POIIndex))
        {
            POIIndex = 0;
        }

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
        if (AIMover && !AIMover.hasPath)
        {
            return typeof(IdleState);
        }

        if (LineOfSightComponent && LineOfSightComponent.HasSeenPlayerThisFrame())
        {
            return typeof(ChasingState);
        }

        return null;
    }
}

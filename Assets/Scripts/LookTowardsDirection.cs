using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsDirection : MonoBehaviour
{
    [SerializeField] private Transform TargetTransformToModify;

    private Vector3 FaceDirection = Vector3.zero;

    private void Start()
    {
        // If None Set In Inspector We Assume This Object
        if (TargetTransformToModify == null)
        {
            TargetTransformToModify = transform;
            FaceDirection = transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TargetTransformToModify.rotation = Quaternion.Slerp(TargetTransformToModify.rotation, Quaternion.LookRotation(FaceDirection), 0.15f);
    }

    private void SetTransformToRotate(Transform NewTransformToModify)
    {
        TargetTransformToModify = NewTransformToModify;
    }

    private void SetDirection(Vector2 Direction)
    {
        if (Direction.sqrMagnitude < 0.1f)
            TargetTransformToModify.rotation = Quaternion.Slerp(TargetTransformToModify.rotation, Quaternion.LookRotation(FaceDirection), 1.0f); // Snap To Final Position

        this.FaceDirection = Direction;
    }

    //private void FaceDirection(Vector3 direction)
    //{
    //    if (direction.sqrMagnitude > 0.1f)
    //}
}

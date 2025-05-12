using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RudimentaryPlayer : MonoBehaviour
{
    [SerializeField] private InputActionReference MovementAction;
    [SerializeField] private InputActionReference JumpAction;
    [SerializeField] private float MovementSpeed = 2.0f;
    [SerializeField] private float JumpImpulseForce = 5.0f;
    [SerializeField] private float DistanceMultiplier = 0.52f;
    
    private Rigidbody myRigidbody = null;

    private Vector3 WorldDirection = Vector3.zero;
    private bool IsJumping = false;
    private bool IsGrounded = false;
    
    private void OnEnable()
    {
        MovementAction.action.Enable();
        JumpAction.action.Enable();
    }

    private void OnDisable()
    {
        MovementAction.action.Disable();
        JumpAction.action.Disable();
    }

    private void Awake()
    {
        // Three Types Of Actions
        //MovementAction.action.started += ActionStarted;
        MovementAction.action.performed += OnLocomtionActionPerformed;
        //MovementAction.action.canceled += OnLocomtionActionPerformed; // Considering They're Doing The Exact Same Thing, I'll Register The Same Action That's It
        
        JumpAction.action.performed += OnJumpActionPerformed;
        JumpAction.action.canceled += OnJumpActionCancelled;

        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        IsGrounded = Physics.Raycast(transform.position, -transform.up, DistanceMultiplier);

        Debug.DrawLine(transform.position, transform.position - transform.up * DistanceMultiplier, Color.red);
    }

    private void FixedUpdate()
    {
#if UNITY_6_0_OR_NEWER
        Vector3 CurrentVelocity = myRigidbody.linearVelocity;
        myRigidbody.linearVelocity = new Vector3(WorldDirection.x * MovementSpeed, CurrentVelocity.y, WorldDirection.z * MovementSpeed);
#else
        Vector3 CurrentVelocity = myRigidbody.velocity;
        myRigidbody.velocity = new Vector3(WorldDirection.x * MovementSpeed, CurrentVelocity.y, WorldDirection.z * MovementSpeed);
#endif
        if (IsGrounded && IsJumping)
        {
            myRigidbody.AddForce(Vector3.up * JumpImpulseForce, ForceMode.Impulse);
        }
    }

    #region InputCallbacks

    private void OnLocomtionActionPerformed(InputAction.CallbackContext CallbackContext)
    {
        Vector2 Input = CallbackContext.ReadValue<Vector2>();

        WorldDirection.x = Input.x;
        WorldDirection.z = Input.y;
    }
    
    private void OnJumpActionPerformed(InputAction.CallbackContext CallbackContext)
    {
        IsJumping = true;
    }

    private void OnJumpActionCancelled(InputAction.CallbackContext CallbackContext)
    {
        IsJumping = false;
    }
    
    #endregion
    
    
}

using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private Rigidbody myRigidbody;
    private Camera mainCamera;
    
    // Movement speed
    [SerializeField] private float moveSpeed = 5f;
    
    // Movement smoothing
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 10f;
    
    private Vector3 currentVelocity;
    
    private void Awake()
    {
        if (myRigidbody == null)
            myRigidbody = GetComponent<Rigidbody>();
            
        if (mainCamera == null)
            mainCamera = Camera.main;
            
        // Freeze rotation - we don't want physics to rotate our character
        myRigidbody.freezeRotation = true;
    }
    
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Apply deceleration when no input
        if (horizontalInput == 0 && verticalInput == 0)
        {
            if (currentVelocity.magnitude > 0)
            {
                currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, deceleration * Time.deltaTime);
                if (currentVelocity.magnitude < 0.1f)
                    currentVelocity = Vector3.zero;
            }
            return;
        }
        
        // Create a movement vector from input
        Vector3 movementInput = new Vector3(horizontalInput, 0, verticalInput).normalized;
        
        // Get camera forward and right vectors, flattened to XZ plane
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();
        
        // Calculate movement direction relative to camera
        Vector3 moveDirection = cameraRight * movementInput.x + cameraForward * movementInput.z;
        
        // Apply acceleration to current velocity
        Vector3 targetVelocity = moveDirection * moveSpeed;
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        // Apply the movement in FixedUpdate for consistent physics
        if (currentVelocity != Vector3.zero)
        {

            myRigidbody.velocity = new Vector3(currentVelocity.x, myRigidbody.velocity.y, currentVelocity.z);
            
            // Rotate character to face movement direction
            if (currentVelocity.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(currentVelocity.x, 0, currentVelocity.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
            }
        }
    }
}
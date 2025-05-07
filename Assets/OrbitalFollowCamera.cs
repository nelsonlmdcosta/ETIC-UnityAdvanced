using UnityEngine;

public class OrbitalFollowCamera : MonoBehaviour
{
    // Target to orbit around
    [SerializeField] private Transform target;
    
    [SerializeField] private float distance = 5.0f;
    
    [SerializeField] private float xSpeed = 120.0f;
    [SerializeField] private float ySpeed = 120.0f;
    
    [SerializeField] private float yMinLimit = -20f;
    [SerializeField] private float yMaxLimit = 80f;
    
    // Current rotation angles
    private float x = 0.0f;
    private float y = 0.0f;
    
    // Smooth damping parameters
    public float smoothTime = 0.1f;
    private Vector3 currentVelocity = Vector3.zero;
    
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }
    
    void LateUpdate()
    {
        if (target == null)
            return;
            
        // Get input for rotation
        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
        
        // Clamp y angle
        y = ClampAngle(y, yMinLimit, yMaxLimit);
        
        // Calculate rotation and position
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 targetPosition = target.position;
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 desiredPosition = targetPosition + rotation * negDistance;
        
        // Apply smoothing when moving the camera
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);
        
        // Make the camera look at the target
        transform.LookAt(target);
    }
    
    // Helper function to clamp angle between min and max
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
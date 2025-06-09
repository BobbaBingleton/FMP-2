using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;              // The player
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // Default camera offset
    [SerializeField] private float smoothSpeed = 0.1f;      // Camera follow smooth speed
    [SerializeField] private float xMinThreshold = 1f;      // X-axis threshold for camera movement
    [SerializeField] private float xMaxThreshold = 1f;      // X-axis threshold for camera movement

    private Vector3 velocity = Vector3.zero;
    private float screenWidth;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target (Player) not assigned to CameraFollow script.");
            return;
        }

        // Get screen width in world units
        screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Calculate desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Get the current camera position
        Vector3 currentPosition = transform.position;

        // Check if the player has moved past the threshold (left or right)
        if (Mathf.Abs(target.position.x - currentPosition.x) > xMaxThreshold)
        {
            // If the player has crossed the X-axis boundary, follow them.
            desiredPosition.x = target.position.x + offset.x;
        }

        // Smoothly move the camera horizontally
        transform.position = Vector3.SmoothDamp(currentPosition, desiredPosition, ref velocity, smoothSpeed);
    }
}


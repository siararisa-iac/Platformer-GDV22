using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Camera camera;

    [SerializeField]
    private GameObject followTarget;

    [SerializeField]
    private Vector2 deadZone;

    [SerializeField]
    private Vector3 positionOffset;

    [SerializeField]
    private float smoothSpeed = 0.5f;

    [SerializeField]
    private float followSpeed = 10f;

    // Tracks the center point of the deadzone
    private Vector3 deadZoneCenter;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void Start()
    {
        // Initialize the center of the dead zone to the target's position
        deadZoneCenter = followTarget.transform.position;
    }

    // Call camera movement in late update to ensure
    // All other position changes are updated.
    // Late Update is called after all updates (Update(), FixedUpdate(), etc)
    private void LateUpdate()
    {
        // Dont do anything if we dont have a target
        if (followTarget == null)
        {
            return;
        }

        // How dead zones work:
        // The camera will not move while the target is within the dead zone
        // The camera will follow the target if they move out of the dead zone

        Vector3 targetPosition = followTarget.transform.position;

        // Calculate how much the player has moved away from the deadzoneCenter
        Vector3 deadZoneOffset = targetPosition - deadZoneCenter;

        // When checking if we go out of bounds from the deadzone, we use absolute value
        // so any directions are covered
        Vector2 absDeadZoneOffset = new(Mathf.Abs(deadZoneOffset.x), Mathf.Abs(deadZoneOffset.y));

        // If we exceed the deadzone, that's when we follow
        if(absDeadZoneOffset.x > deadZone.x)
        {
            // Direction matters when camera needs to follow player
            // Mathf.Sign returns either 1 or -1. Helpful for determining if movement goes right/left
            float xDirection = Mathf.Sign(deadZoneOffset.x);
            // Deadzone moves to adjust its center
            deadZoneCenter.x = targetPosition.x - (xDirection * deadZone.x);
        }
        if (absDeadZoneOffset.y > deadZone.y)
        {
            float yDirection = Mathf.Sign(deadZoneOffset.y);
            deadZoneCenter.y = targetPosition.y - (yDirection * deadZone.y);
        }

        // Add the offset to the deadZone's updated center
        Vector3 desiredPosition = deadZoneCenter + positionOffset;
        // Apply smoothing to the position
        Vector3 smoothPosition = Vector3.Lerp(camera.transform.position, desiredPosition, followSpeed * smoothSpeed * Time.deltaTime);
        camera.transform.position = smoothPosition;
    }

    // Visualize the dead zone
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(deadZoneCenter, deadZone * 2);
    }
}

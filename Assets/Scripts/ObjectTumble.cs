using UnityEngine;

public class ObjectTumble : MonoBehaviour
{
    private Rigidbody rb;
    private bool startFalling = false;
    private float timeToStartFalling = 20f; // Time to start falling in seconds
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private bool hasFlipped = false; // Flag to track if the object has flipped

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Initially, object is kinematic
        targetPosition = new Vector3(-71f, 13.9f, 43.8f); // Target position
        targetRotation = Quaternion.Euler(0f, 64.772f, 0f); // Target rotation
    }

    void Update()
    {
        // Start counting time after 20 seconds
        if (Time.time >= timeToStartFalling && !startFalling)
        {
            startFalling = true;
            rb.isKinematic = false; // Enable physics
        }

        // If the object has started falling and hasn't flipped yet, flip it once
        if (startFalling && !hasFlipped)
        {
            FlipObject();
            hasFlipped = true;
        }
    }

    // Method to flip the object once and bring it to the target position and rotation
    private void FlipObject()
    {
        // Calculate the rotation needed to reach the target rotation
        Quaternion deltaRotation = targetRotation * Quaternion.Inverse(transform.rotation);

        // Convert the rotation to euler angles and apply as torque
        Vector3 torque = deltaRotation.eulerAngles * 10f;
        rb.AddTorque(torque, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        // If the object has flipped and reached the target position and rotation, stop it
        if (hasFlipped && Vector3.Distance(transform.position, targetPosition) < 0.1f && Quaternion.Angle(transform.rotation, targetRotation) < 1f)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}

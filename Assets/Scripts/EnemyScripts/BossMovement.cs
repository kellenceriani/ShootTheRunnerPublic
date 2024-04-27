using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float floatHeight = 0.5f; // Height the object will float above its initial position
    public float floatSpeed = 1.0f; // Speed of the floating movement
    public float twirlSpeed = 50.0f; // Speed of the twirl rotation

    private Vector3 startPosition;
    private bool twirlDirection = true; // True for clockwise, false for counter-clockwise

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Floating movement
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Twirl rotation
        if (twirlDirection)
        {
            transform.Rotate(Vector3.up, twirlSpeed * Time.deltaTime);
            if (transform.rotation.eulerAngles.y >= 210) // Check if reached maximum rotation
                twirlDirection = false; // Change direction to counter-clockwise
        }
        else
        {
            transform.Rotate(Vector3.up, -twirlSpeed * Time.deltaTime); // Counter-clockwise rotation
            if (transform.rotation.eulerAngles.y <= 190) // Check if reached minimum rotation
                twirlDirection = true; // Change direction to clockwise
        }
    }
}

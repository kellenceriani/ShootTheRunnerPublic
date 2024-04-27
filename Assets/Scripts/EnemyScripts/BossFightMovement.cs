using UnityEngine;

public class BossFightMovement : MonoBehaviour
{
    public float floatHeight = 0.5f; // Height the object will float above its initial position
    public float floatSpeed = 1.0f; // Speed of the floating movement
    public float twirlSpeed = 50.0f; // Speed of the twirl rotation

    public Vector3 minPosition;
    public Vector3 maxPosition;

    private Vector3 startPosition;
    private bool twirlDirection = true; // True for clockwise, false for counter-clockwise

    private Vector3 minScale = new Vector3(150f, 150f, 150f); // Minimum scale
    private Vector3 maxScale = new Vector3(396.7957f, 396.7957f, 396.7957f); // Current scale

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

        // Random movement within specified coordinates
        if (Random.Range(0, 100) < 1) // Adjust this probability to control how often the movement occurs
        {
            Vector3 randomPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x), transform.position.y, Random.Range(minPosition.z, maxPosition.z));
            transform.position = randomPosition;
        }

        // Scale interpolation
        float t = Mathf.PingPong(Time.time, 1) / 1; // PingPong function to create oscillation between 0 and 1
        transform.localScale = Vector3.Lerp(minScale, maxScale, t);
    }
}

using UnityEngine;

public class MoveCube : MonoBehaviour
{
    // Define the target position
    public Vector3 targetPosition = new Vector3(-16.6f, 10.1f, -31.4f);

    // Define the speed of movement
    public float moveSpeed = 5f;

    // Define the delay before the cube starts moving
    public float startDelay = 20f;
    private float currentDelay;

    // Flag to check if the delay has passed
    private bool delayPassed = false;

    // Use this for initialization
    void Start()
    {
        // Set the initial delay countdown
        currentDelay = startDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // If delay has passed, start moving the cube
        if (delayPassed)
        {
            // Move the cube towards the target position over time
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the cube has reached the target position
            if (transform.position == targetPosition)
            {
                // Optional: Do something when the cube reaches the target position
                // Debug.Log("Cube has reached the target position!");
            }
        }
        else
        {
            // Countdown the delay
            currentDelay -= Time.deltaTime;

            // If delay is over, set delayPassed flag to true
            if (currentDelay <= 0)
            {
                delayPassed = true;
            }
        }
    }
}

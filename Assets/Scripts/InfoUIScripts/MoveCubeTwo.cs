using UnityEngine;

public class MoveCubeTwo : MonoBehaviour
{
    // Define the target position
    public Vector3 targetPosition = new Vector3(-16.6f, 10.1f, -31.4f);

    // Define the speed of movement
    public float moveSpeed = 5f;

    // Use this for initialization
    void Start()
    {
        // Move the cube to the target position
        transform.position = new Vector3(-16.6f, -9.65f, -31.4f);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the cube towards the target position over time
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Check if the cube has reached the target position
        if (transform.position == targetPosition)
        {
            // Optional: Do something when the cube reaches the target position
            //Debug.Log("Cube has reached the target position!");
        }
    }
}

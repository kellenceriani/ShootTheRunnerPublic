using UnityEngine;
using UnityEngine.InputSystem;

public class XRAndMouseControl : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float lookSpeed = 2f;
    public LineRenderer raycastLine;

    private InputAction moveAction;

    private void OnEnable()
    {
        // Enable the move action for WASD keys
        moveAction = new InputAction(binding: "<Keyboard>/WASD");
        moveAction.Enable();

        // Subscribe to the move action's performed event
        moveAction.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        // Disable the move action and unsubscribe from its events
        moveAction.Disable();
        moveAction.performed -= ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        // Move the XR rig based on input
        Vector3 moveDirection = new Vector3(direction.x, 0f, direction.y);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        Debug.Log("Keyboard Input: " + moveDirection);
    }

    private void Update()
    {
        // Handle rotation based on mouse input
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        Vector3 rotateDirection = new Vector3(-mouseDelta.y * lookSpeed * Time.deltaTime, mouseDelta.x * lookSpeed * Time.deltaTime, 0f);
        transform.Rotate(rotateDirection, Space.Self);

        // Cast a ray forward from the camera to visualize where the player is looking
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            raycastLine.SetPosition(0, Camera.main.transform.position);
            raycastLine.SetPosition(1, hit.point);
        }

        // Handle XRI triggers with mouse clicks
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Left Trigger Pressed");
            // Handle left trigger press
        }
        if (mouse.rightButton.wasPressedThisFrame)
        {
            Debug.Log("Right Trigger Pressed");
            // Handle right trigger press
        }
    }
}

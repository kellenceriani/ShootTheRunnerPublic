using UnityEngine;
using TMPro;

public class TextChangeAfterDelay : MonoBehaviour
{
    [System.Serializable]
    public struct TextChangeInfo
    {
        public string newText;
        public float delay;
    }

    public TextMeshProUGUI textMesh;
    public TextChangeInfo[] textChanges;
    public GameObject objectToMove;
    public GameObject objectToDisable;

    private int currentChangeIndex = 0;
    private float timer = 0f;
    private bool textChanged = false;
    private bool allTextChangesCompleted = false;
    private bool objectsChanged = false;
    private float objectChangeDelay = 5f;

    void Start()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>(); // Automatically find the TextMeshProUGUI component
        if (textMesh == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the child GameObject.");
            return;
        }

        // Start the timer for the first change
        StartNextTextChange();
    }

    void Update()
    {
        // If all text changes have not been completed, update text changes
        if (!allTextChangesCompleted)
        {
            UpdateTextChanges();
        }
        else // If all text changes have been completed, enable/disable objects with delay
        {
            // Countdown the timer for object change delay
            objectChangeDelay -= Time.deltaTime;
            if (objectChangeDelay <= 0f && !objectsChanged)
            {
                EnableDisableObjects();
            }
        }
    }

    void UpdateTextChanges()
    {
        // If text has already changed, no need to update further
        if (textChanged)
            return;

        // Countdown the timer
        timer -= Time.deltaTime;

        // If the timer reaches zero, change the text
        if (timer <= 0f)
        {
            ChangeText();
        }
    }

    void ChangeText()
    {
        // Change the text
        textMesh.text = textChanges[currentChangeIndex].newText;
        textChanged = true; // Set textChanged to true to prevent further updates

        // Move to the next change if available
        currentChangeIndex++;
        if (currentChangeIndex < textChanges.Length)
        {
            // Start the timer for the next change
            StartNextTextChange();
        }
        else
        {
            // All text changes have been completed
            allTextChangesCompleted = true;
        }
    }

    void EnableDisableObjects()
    {
        // Disable the objects if assigned
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
        // Move the object if assigned
        if (objectToMove != null)
        {
            objectToMove.transform.position = new Vector3(-16.12598f, 0.8299999f, -74.93f);
            objectToMove.transform.rotation = Quaternion.Euler(10.8f, 1.013f, 0f);
        }

        objectsChanged = true; // Set objectsChanged to true to prevent further updates
    }


    void StartNextTextChange()
    {
        timer = textChanges[currentChangeIndex].delay;
        textChanged = false;
    }
}

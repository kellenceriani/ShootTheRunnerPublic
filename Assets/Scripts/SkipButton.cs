using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SkipButton : MonoBehaviour
{

    public GameObject objectToMove;
    public GameObject objectToDisable;
    public GameObject objectToDisableTwo;

    // Method to skip text changes and enable/disable objects
    public void SkipTextChanges(SelectEnterEventArgs args)
    {
        Debug.Log("SkipTextChanges method called");
        // Disable the objects if assigned
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
        if (objectToDisableTwo != null)
        {
            objectToDisableTwo.SetActive(false);
        }
        // Move the object if assigned
        if (objectToMove != null)
        {
            objectToMove.transform.position = new Vector3(-16.12598f, 0.8299999f, -74.93f);
            objectToMove.transform.rotation = Quaternion.Euler(10.8f, 1.013f, 0f);
        }
    }
}

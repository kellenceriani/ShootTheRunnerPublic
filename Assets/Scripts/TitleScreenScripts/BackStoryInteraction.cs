using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class BackStoryInteraction : MonoBehaviour
{
    public GameObject clipHolder; // Reference to the ClipHolder object
    public GameObject publicObject; // Reference to the public object to be disabled

    void Start()
    {
        // Find the BackStoryButton object
        GameObject backButton = GameObject.Find("BackStoryButton");

        // Check if the BackStoryButton object is found
        if (backButton != null)
        {
            XRGrabInteractable grabInteractable = backButton.GetComponent<XRGrabInteractable>();

            // Check if XRGrabInteractable component is found
            if (grabInteractable != null)
            {
                grabInteractable.selectEntered.AddListener(OnGrabbed);
            }
            else
            {
                Debug.LogError("XRGrabInteractable not found on BackstoryButton object.");
            }
        }
        else
        {
            Debug.LogError("BackStoryButton object not found in the scene.");
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("BackstoryButton grabbed. Enabling ClipHolder and disabling public object...");
        clipHolder.SetActive(true); // Enable the ClipHolder object
        publicObject.SetActive(false); // Disable the public object
    }
}

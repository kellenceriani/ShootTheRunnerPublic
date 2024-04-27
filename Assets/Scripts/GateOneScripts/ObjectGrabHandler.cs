using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement; // Add this line to use SceneManager

public class ObjectGrabHandler : MonoBehaviour
{
    //public GameObject objectToTeleportAndChange;
    public GameObject objectToDisable;

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable == null)
        {
            Debug.LogError("ObjectGrabHandler script requires XRGrabInteractable component!");
            enabled = false;
            return;
        }

        grabInteractable.selectEntered.AddListener(OnGrabEntered);
    }

    private void OnGrabEntered(SelectEnterEventArgs args)
    {
        // Load the "GateOne" scene
        SceneManager.LoadScene("GateOne");

        //// Disable the object if specified
        //if (objectToDisable != null)
        //{
        //    objectToDisable.SetActive(false);
        //}
    }
}

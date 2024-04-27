using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
        else
        {
            Debug.LogError("XRGrabInteractable not found on LevelOneStart object.");
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log("LevelOneStart grabbed. Loading Level One...");
        SceneManager.LoadScene("LevelOne");
    }
}

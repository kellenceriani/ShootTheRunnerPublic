using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CreditsShow : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject objectToDisable;

    public void OnStartButtonSelected(SelectEnterEventArgs args)
    {
        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }
    }
    public void OnExitButtonSelected(SelectEnterEventArgs args)
    {

        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }
}
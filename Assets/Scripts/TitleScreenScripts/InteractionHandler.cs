using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractionHandler : MonoBehaviour
{
    public List<GameObject> nextObject; // Object to be enabled when NextButton is grabbed
    [SerializeField] int nextIndex = 0;

    public void OnNextGrabbed(SelectEnterEventArgs args)
    {
        if (nextIndex + 1 > nextObject.Count)
            return;

        Debug.Log("NextButton grabbed. Enabling nextObject and disabling disableObject...");
        nextIndex++;
        EnableDisableObjects();
    }

    public void OnExitGrabbed(SelectEnterEventArgs args)
    {
        if (nextIndex - 1 < 0)
        {
            nextObject[nextIndex].SetActive(false); // Enable the nextObject
            return;
        }

        Debug.Log("NextButton grabbed. Enabling nextObject and disabling disableObject...");
        nextIndex--;
        EnableDisableObjects();
    }

    public void Reread(SelectEnterEventArgs args)
    {

        {
            nextIndex = 1;
            EnableDisableObjects();
        }

    }

    public void BackToMain(SelectEnterEventArgs args)
    {
        nextIndex = 0;
        EnableDisableObjects();
    }

    private void EnableDisableObjects()
    {
        for (int i = 0; i < nextObject.Count; i++)
        {
            nextObject[i].SetActive(i == nextIndex);
        }
    }
}

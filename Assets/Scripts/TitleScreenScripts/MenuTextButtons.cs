using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuTextButtons : MonoBehaviour
{
    public TextMeshPro startGameText;
    public TextMeshPro backStoryText;
    public TextMeshPro creditsText;

    private void Start()
    {
        // Ensure the references are set in the Unity Editor
        if (startGameText == null || backStoryText == null || creditsText == null)
        {
            Debug.LogError("Please assign all TextMeshProUGUI objects in the inspector.");
        }
    }
}

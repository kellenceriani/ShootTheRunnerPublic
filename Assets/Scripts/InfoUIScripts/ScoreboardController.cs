using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardController : MonoBehaviour
{
    public TextMeshPro runnerOneSpeedText;
    public TextMeshPro runnerTwoSpeedText;
    public TextMeshPro runnerThreeSpeedText;

    private void Start()
    {
        // Ensure the references are set in the Unity Editor
        if (runnerOneSpeedText == null || runnerTwoSpeedText == null || runnerThreeSpeedText == null)
        {
            Debug.LogError("Please assign all TextMeshProUGUI objects in the inspector.");
        }
    }

    public void UpdateRunnerSpeed(Transform runnerBase, float speed)
    {
        // Check the runner base position and update the corresponding text field
        if (runnerBase == null)
        {
            Debug.LogError("Runner base transform is null.");
            return;
        }

        // Format the speed to 2 decimals and add "mph"
        string formattedSpeed = speed.ToString("0.00") + " mph";

        if (runnerBase.name == "1stBase")
        {
            runnerOneSpeedText.text = "Speed 1 (" + runnerBase.name + "): " + formattedSpeed;
        }
        else if (runnerBase.name == "2ndBase")
        {
            runnerTwoSpeedText.text = "Speed 2 (" + runnerBase.name + "): " + formattedSpeed;
        }
        else if (runnerBase.name == "3rdBase")
        {
            runnerThreeSpeedText.text = "Speed 3 (" + runnerBase.name + "): " + formattedSpeed;
        }
        else
        {
            Debug.LogError("Invalid runner base position.");
        }
    }
}

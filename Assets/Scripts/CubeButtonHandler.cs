using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CubeButtonHandler : MonoBehaviour
{
    // Reference to the InputData script
    public InputData inputData;

    // Scene name to load for primary button
    public string primaryButtonScene = "LevelOne";

    // Scene name to load for secondary button
    public string secondaryButtonScene = "GateOne";

    // Update is called once per frame
    void Update()
    {
        if (inputData._rightController.isValid)
        {
            // Check if the "a" button is pressed (Primary Button)
            if (inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isAPressed) && isAPressed)
            {
                // Load the new scene
                SceneManager.LoadScene(primaryButtonScene);
            }

            // Check if the "y" button is pressed (Secondary Button)
            if (inputData._rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isYPressed) && isYPressed)
            {
                // Load the new scene
                SceneManager.LoadScene(secondaryButtonScene);
            }
        }
    }
}

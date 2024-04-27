using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovementSound : MonoBehaviour
{
    private XRController xrController;  // or XRDirectInteractor, or whichever component you are using for player movement
    private AudioSource audioSource;

    private void Start()
    {
        xrController = GetComponent<XRController>();  // Make sure to adjust this based on your setup
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (xrController)
        {
            // Check for movement input or whatever conditions you want to trigger the sound
            if (xrController.inputDevice.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity) && velocity.magnitude > 0.1f)
            {
                PlayMovementSound();
            }
        }
    }

    private void PlayMovementSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

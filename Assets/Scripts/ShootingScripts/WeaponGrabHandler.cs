using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponGrabHandler : MonoBehaviour
{
    public GameObject objectToDisable; // Assign the object to be disabled in the Inspector

    private EnemyProjectileLauncher projectileLauncher;

    void Start()
    {
        projectileLauncher = FindObjectOfType<EnemyProjectileLauncher>();
        if (projectileLauncher == null)
        {
            Debug.LogError("EnemyProjectileLauncher not found in the scene.");
            return;
        }

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("XRGrabInteractable component not found on the weapon object.");
            return;
        }

        grabInteractable.selectEntered.AddListener(OnWeaponGrabbed);
    }

    private void OnWeaponGrabbed(SelectEnterEventArgs args)
    {
        projectileLauncher.AllowSpawnProjectiles();
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false); // Disable the object
        }
    }
}

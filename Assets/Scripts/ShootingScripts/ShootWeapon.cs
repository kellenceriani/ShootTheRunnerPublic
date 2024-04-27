using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ShootWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _launchPosition, _bulletPrefab;
    [SerializeField] private AudioSource _shootSound;
    private bool _okayToShoot = false;
    private bool _shootingPaused = false;
    private InputData _inputData;
    private bool _okayToExit = true;

    public GameObject weaponObject; // Reference to the Weapon GameObject
    private Animator _weaponAnimator; // Animator component of the weapon object

    public GameObject objectToDisable; // Public GameObject to disable when the weapon is grabbed

    void Start()
    {
        _inputData = GetComponent<InputData>();
        _shootSound = GetComponent<AudioSource>();

        if (_shootSound == null)
        {
            Debug.LogError("AudioSource component not found! Make sure it's attached to the same GameObject as this script.");
        }

        // Find the Weapon GameObject with the tag "Weapon"
        weaponObject = GameObject.FindGameObjectWithTag("Weapon");
        if (weaponObject == null)
        {
            Debug.LogError("Weapon GameObject not found with the tag 'Weapon'.");
        }
        else
        {
            _weaponAnimator = weaponObject.GetComponent<Animator>();
            if (_weaponAnimator == null)
            {
                Debug.LogError("Animator component not found on the Weapon GameObject.");
            }
        }
    }

    void Update()
    {
        if (_okayToShoot)
        {
            if (!_shootingPaused)
            {
                if ((_inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float leftTriggerValue) && leftTriggerValue > 0.5f) ||
                    (_inputData._rightController.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerValue) && rightTriggerValue > 0.5f))
                {
                    if (_weaponAnimator != null)
                    {
                        _weaponAnimator.SetTrigger("shoot");
                        _shootingPaused = true;
                        Fire();
                        StartCoroutine(Pause());
                    }
                }
            }
        }
    }

    private void Fire()
    {
        _shootSound.Play(); // Play the shooting sound
        GameObject bullet = Instantiate(_bulletPrefab) as GameObject;
        bullet.SetActive(true);
        bullet.transform.position = _launchPosition.transform.position;
        bullet.transform.rotation = _launchPosition.transform.rotation;

        bullet.GetComponent<Rigidbody>().AddForce(_launchPosition.transform.forward * 150f, ForceMode.Impulse);
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        _shootingPaused = false;
    }

    public void PickedUpWeaponTrigger()
    {
        _okayToShoot = true;
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }

    public void DroppedWeaponTrigger()
    {
        _okayToShoot = false;
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(true);
        }
    }
}

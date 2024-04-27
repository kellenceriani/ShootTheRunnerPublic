using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{
    public GameObject NewRunner; // Reference to the Runner3 GameObject
    public int EnemyHealth = 1;
    public AudioSource deathAudioSource;

    void Start()
    {
        //Add Audio Component
        deathAudioSource = GetComponent<AudioSource>();
        if (deathAudioSource == null)
        {
            deathAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            Debug.Log("Enemy has Died");
            Died();
        }
    }

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        Debug.Log("Enemy Health: " + EnemyHealth); // Add this debug log
        GameObject CanvasChild = transform.GetChild(0).gameObject;
        GameObject HealthBarChild = CanvasChild.transform.GetChild(0).gameObject;
        HealthBarChild.GetComponent<EnemyHealthBar>().ChangeHealth(EnemyHealth);
    }

    private void Died()
    {
        // Play the death sound
        deathAudioSource.Play();

        //Debug.Log("Enemy Died");
        Debug.Log("Runner is not running. Destroying object.");
        NewRunner.SetActive(true);
        Destroy(gameObject);
        //SceneManager.LoadScene("Win");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class EnemyStatsTwo : MonoBehaviour
{
    public GameObject NewRunner; // Reference to the Runner3 GameObject
    public GameObject SecondNewRunner; // Reference to the Runner4 GameObject
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
            Died();
        }
    }

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        GameObject CanvasChild = transform.GetChild(0).gameObject;
        GameObject HealthBarChild = CanvasChild.transform.GetChild(0).gameObject;
        HealthBarChild.GetComponent<EnemyHealthBar>().ChangeHealth(EnemyHealth);
    }

    private void Died()
    {
        // Play the death sound
        deathAudioSource.Play();

        // Set the specified game objects active
        NewRunner.SetActive(true);
        SecondNewRunner.SetActive(true);
        Destroy(gameObject);
        //SceneManager.LoadScene("Win");
    }
}

using System.Collections;
using UnityEngine;

public class EnemyProjectileLauncher : MonoBehaviour
{
    public GameObject baseballPrefab;
    public Transform launchPosition;
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    public Transform playerTransform;
    private int playerHits = 0;
    private bool canSpawnProjectiles = false;

    void Start()
    {
        // Don't start spawning projectiles immediately
        StartCoroutine(WaitForWeaponGrab());
    }

    IEnumerator WaitForWeaponGrab()
    {
        // Wait until the weapon is grabbed
        yield return new WaitUntil(() => canSpawnProjectiles);

        // Start spawning projectiles
        StartCoroutine(SpawnProjectiles());
    }

    IEnumerator SpawnProjectiles()
    {
        while (true)
        {
            // Spawn projectile
            GameObject baseball = Instantiate(baseballPrefab, launchPosition.position, Quaternion.identity);
            Rigidbody rb = baseball.GetComponent<Rigidbody>();

            // Randomize size slightly
            float randomSize = Random.Range(0.9f, 1.1f);
            baseball.transform.localScale *= randomSize;

            // Calculate direction towards the player
            Vector3 directionToPlayer = (playerTransform.position - launchPosition.position).normalized;

            // Apply velocity directly towards the player
            rb.velocity = directionToPlayer.normalized * Random.Range(minSpeed, maxSpeed);

            // Destroy projectile after 8 seconds
            Destroy(baseball, 8f);

            // Wait for 1 second before spawning the next projectile
            yield return new WaitForSeconds(4f);
        }
    }

    public void IncreasePlayerHits()
    {
        playerHits++;
        Debug.Log("Hit count: " + playerHits);

        if (playerHits >= 1)
        {
            // Activate the LoseSceneLoader
            LoseSceneLoader loseSceneLoader = FindObjectOfType<LoseSceneLoader>();
            if (loseSceneLoader != null)
            {
                loseSceneLoader.TriggerSpawnObjectsWithDelay(0.5f); // Adjust delay as needed
            }
            else
            {
                Debug.LogError("LoseSceneLoader not found in the scene.");
            }
        }
    }

    public void AllowSpawnProjectiles()
    {
        canSpawnProjectiles = true;
    }
}

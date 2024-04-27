using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseSceneLoader : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnAreaCenter;
    public Vector3 spawnAreaSize;

    // Change the access modifier of SpawnObjects to private
    private void SpawnObjects()
    {
        Debug.Log("Spawning objects...");
        StartCoroutine(SpawnObjectsCoroutine());
    }

    private IEnumerator SpawnObjectsCoroutine()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        // Deactivate box colliders for objects with the tag "Enemy"
        foreach (GameObject enemy in enemyObjects)
        {
            BoxCollider collider = enemy.GetComponent<BoxCollider>();
            if (collider != null)
            {
                collider.enabled = false;
            }
        }

        for (int i = 0; i < 50; i++)
        {
            Vector3 spawnPosition = GenerateRandomSpawnPosition();
            Debug.Log($"Spawn position: {spawnPosition}");
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            spawnedObject.SetActive(true); // Ensure the object is enabled
            yield return new WaitForSeconds(0.02f); // Wait for 0.2 seconds before spawning the next object
        }

        // Start the countdown to change scenes after 1 second
        StartCoroutine(ChangeSceneAfterDelay(1f));
    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Changing to Lose scene...");
        SceneManager.LoadScene("Lose"); // Change to the "Lose" scene
    }

    // Public method to trigger spawning objects
    public void TriggerSpawnObjectsWithDelay(float delay)
    {
        StartCoroutine(SpawnObjectsWithDelayCoroutine(delay));
    }

    private IEnumerator SpawnObjectsWithDelayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnObjects();
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        float x = Random.Range(spawnAreaCenter.position.x - spawnAreaSize.x / 2, spawnAreaCenter.position.x + spawnAreaSize.x / 2);
        float y = Random.Range(spawnAreaCenter.position.y - spawnAreaSize.y / 2, spawnAreaCenter.position.y + spawnAreaSize.y / 2);
        float z = Random.Range(spawnAreaCenter.position.z - spawnAreaSize.z / 2, spawnAreaCenter.position.z + spawnAreaSize.z / 2);

        return new Vector3(x, y, z);
    }
}

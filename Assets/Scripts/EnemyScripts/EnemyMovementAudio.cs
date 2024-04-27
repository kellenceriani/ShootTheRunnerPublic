using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _enemyMovementSound;
    private Dictionary<GameObject, Vector3> _enemyPositions = new Dictionary<GameObject, Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        _enemyMovementSound = GetComponent<AudioSource>();

        if (_enemyMovementSound == null)
        {
            Debug.LogError("AudioSource component not found! Make sure it's attached to the same GameObject as this script.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for enemy movement and play sound if detected
        CheckEnemyMovement();
    }

    private void CheckEnemyMovement()
    {
        // Check for all objects tagged as "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Loop through each enemy
        foreach (GameObject enemy in enemies)
        {
            // Check if the enemy exists in the dictionary
            if (!_enemyPositions.ContainsKey(enemy))
            {
                // If not, add it to the dictionary
                _enemyPositions.Add(enemy, enemy.transform.position);
                continue;
            }

            // Check if the enemy's position has changed
            if (_enemyPositions[enemy] != enemy.transform.position)
            {
                // Play the enemy movement sound
                _enemyMovementSound.Play();
                // Update the enemy's position in the dictionary
                _enemyPositions[enemy] = enemy.transform.position;
            }
        }
    }
}

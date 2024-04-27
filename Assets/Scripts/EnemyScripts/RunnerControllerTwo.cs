using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class RunnerControllerTwo : MonoBehaviour
{
    public Transform base1;
    public Transform base2;

    public float minMoveSpeed = 5.0f;
    public float maxMoveSpeed = 13.0f;
    private bool isRunning = false;
    private bool canStartRunning = false;
    private ScoreboardController scoreboardController;
    public AudioSource runnerAudioSource; // Add this line

    void Awake()
    {
        scoreboardController = FindObjectOfType<ScoreboardController>();
        if (scoreboardController == null)
        {
            Debug.LogError("ScoreboardController not found in the scene.");
        }
        // Add an AudioSource component
        runnerAudioSource = GetComponent<AudioSource>();
        if (runnerAudioSource == null)
        {
            runnerAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        StartRunning();
    }

    void Update()
    {
        if (canStartRunning && isRunning)
        {
            float randomSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
            transform.position = Vector3.MoveTowards(transform.position, base2.position, randomSpeed * Time.deltaTime);

            // Play the sound while the runner is moving
            if (!runnerAudioSource.isPlaying)
            {
                runnerAudioSource.Play();
            }

            if (transform.position == base2.position)
            {
                isRunning = false;
                // Call TriggerSpawnObjectsWithDelay only when the runner reaches the second base
                LoseSceneLoader loseSceneLoader = FindObjectOfType<LoseSceneLoader>();
                if (loseSceneLoader != null)
                {
                    // Adjust the delay value as needed
                    loseSceneLoader.TriggerSpawnObjectsWithDelay(0.5f); // Example delay of 2 seconds
                }
                else
                {
                    Debug.LogError("LoseSceneLoader not found in the scene.");
                }
            }
        }
    }

    public void StartRunning()
    {
        canStartRunning = true;
        isRunning = true;
        Debug.Log("Runner started running!");

        // Call UpdateRunnerSpeed with the corresponding runner base position and random speed
        float randomSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        scoreboardController.UpdateRunnerSpeed(base1, randomSpeed);  // Pass the starting base information
    }
}

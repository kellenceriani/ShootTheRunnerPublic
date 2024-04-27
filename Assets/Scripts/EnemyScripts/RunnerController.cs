using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;

public class RunnerController : MonoBehaviour
{
    public Transform base1;
    public Transform base2;
    public float minMoveSpeed = 5.0f;
    public float maxMoveSpeed = 13.0f;

    private bool isRunning = false;
    private bool canStartRunning = false;
    public GameObject StartingInformation;
    private ScoreboardController scoreboardController;
    //public GameObject objectSpawner;

    void Start()
    {
        XRGrabInteractable grabInteractable = GameObject.Find("Weapon").GetComponent<XRGrabInteractable>();
        Debug.Log("found the weapon");

        grabInteractable.selectEntered.AddListener(OnGrabbed);
        Debug.Log("Waiting for the weapon to be grabbed...");

        // Find the ScoreboardController in the scene
        scoreboardController = FindObjectOfType<ScoreboardController>();
        if (scoreboardController == null)
        {
            Debug.LogError("ScoreboardController not found in the scene.");
        }

    }

    void Update()
    {
        if (canStartRunning && isRunning)
        {
            float randomSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
            transform.position = Vector3.MoveTowards(transform.position, base2.position, randomSpeed * Time.deltaTime);

            if (transform.position == base2.position)
            {
                isRunning = false;
                Debug.Log("Runner reached 2ndBase and stopped running.");

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
        scoreboardController.UpdateRunnerSpeed(base1, randomSpeed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        //Debug.Log($"canStartRunning: {canStartRunning}, isRunning: {isRunning}");
        Debug.Log("Time to Start!!");
        StartingInformation.SetActive(false);
        StartRunning();
        Debug.Log("Weapon grabbed. StartRunning method called.");
    }
    // Determine the runner number based on the runner's position
}

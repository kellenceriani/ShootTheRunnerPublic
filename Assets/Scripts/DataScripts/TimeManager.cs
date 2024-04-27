using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;
    private float totalTime = 0f;
    private bool isTimeRunning = true; // Flag to indicate whether time should continue running
    private bool isGameEnded = false; // Flag to indicate if the game has ended
    private float endTime = 0f; // Time when the game ended
    private TextMeshProUGUI timeText; // Reference to your TextMeshPro object

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateTimeText(); // Update time text when the scene starts
        SceneManager.sceneLoaded += OnSceneLoaded; // Register OnSceneLoaded method
    }

    private void Update()
    {
        if (isTimeRunning && !isGameEnded) // Check if time should continue running
        {
            totalTime += Time.deltaTime;
            UpdateTimeText();
        }
    }

    private void UpdateTimeText()
    {
        if (timeText == null)
        {
            // Find objects with the "Time" tag
            GameObject[] timeObjects = GameObject.FindGameObjectsWithTag("Time");

            // Iterate through each object to find the TextMeshProUGUI component
            foreach (GameObject timeObject in timeObjects)
            {
                TextMeshProUGUI tmp = timeObject.GetComponentInChildren<TextMeshProUGUI>();
                if (tmp != null)
                {
                    timeText = tmp;
                    break; // Stop searching once the TextMeshProUGUI is found
                }
            }
        }

        if (timeText != null)
        {
            if (isGameEnded) // Display final time when the game ends
            {
                timeText.text = "Final Time: " + FormatTime(endTime);
            }
            else
            {
                int minutes = Mathf.FloorToInt(totalTime / 60F);
                int seconds = Mathf.FloorToInt(totalTime - minutes * 60);
                string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
                timeText.text = "Time: " + timeString;
            }
        }
    }

    // Method to stop the time
    public void StopTime()
    {
        isTimeRunning = false;
        isGameEnded = true;
        endTime = totalTime; // Record the time when the game ends
        UpdateTimeText(); // Update one last time

        // Store the final time in PlayerPrefs
        PlayerPrefs.SetFloat("FinalTime", endTime);
        PlayerPrefs.Save();
    }

    // Method to resume the time (if needed)
    public void ResumeTime()
    {
        isTimeRunning = true;
    }

    // Method to reset time when "LevelOne" is started
    public void ResetTime()
    {
        totalTime = 0f;
        UpdateTimeText();
    }

    // Method to check for scene changes and stop time if necessary
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Win")
        {
            StopTime();
        }
        else if (scene.name == "LevelOne")
        {
            ResetTime(); // Reset time when LevelOne scene is loaded
        }
        else if (scene.name == "GateOne")
        {
            // Retrieve the final time from PlayerPrefs
            float finalTime = PlayerPrefs.GetFloat("FinalTime", 0f);

            // Use the final time to populate the leaderboard
            // For example, you can update TextMeshProUGUI components in the leaderboard with the final time

            // Example:
            TextMeshProUGUI[] leaderboardTexts = GameObject.Find("Leaderboard").GetComponentsInChildren<TextMeshProUGUI>();
            foreach (TextMeshProUGUI text in leaderboardTexts)
            {
                text.text = "Final Time: " + FormatTime(finalTime);
            }
        }
        else if (scene.name == "LevelOne") // Additional check for re-entering LevelOne
        {
            ResetTime(); // Reset time when LevelOne scene is re-entered
        }
        else
        {
            ResumeTime();
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

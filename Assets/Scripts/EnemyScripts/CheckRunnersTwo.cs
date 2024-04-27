using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckRunnersTwo : MonoBehaviour
{
    public GameObject runner7;
    public GameObject runner8;
    public GameObject runner9;

    void Update()
    {
        // Check if all three runners are destroyed
        if (runner7 == null && runner8 == null && runner9 == null)
        {
            // Load the "Win" scene
            SceneManager.LoadScene("LevelThree");
        }
    }
}

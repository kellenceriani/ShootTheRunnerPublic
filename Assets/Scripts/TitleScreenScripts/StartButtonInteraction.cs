using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class StartButtonInteraction : MonoBehaviour
{

    public void OnStartButtonSelected(SelectEnterEventArgs args)
    {       
            SceneManager.LoadScene("GateSelector");     
    }
}

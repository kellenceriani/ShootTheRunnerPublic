using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIColorTracker : MonoBehaviour
{
    private Material StartingColor;
    private bool hasColorBeenChanged = false;
    private string newColor;

    [SerializeField] private GameObject target;
    private Material TargetStartingColor;
    // Start is called before the first frame update
    private void Start()
    {
        StartingColor = transform.parent.gameObject.GetComponent<Renderer>().material;
        TargetStartingColor = target.GetComponent<Renderer>().material;
    }
    private void OnTriggerEnter(Collider enter)
    {
        if (!hasColorBeenChanged)
        {
            if(enter.transform.gameObject.tag == "ColorCube")
            {
                Debug.Log("Trigger Enter Detected!"); // Add this debug log
                transform.parent.gameObject.GetComponent<Renderer>().material = enter.transform.gameObject.GetComponent<Renderer>().material;
                target.GetComponent<Renderer>().material = enter.gameObject.GetComponent<Renderer>().material;
                newColor = enter.transform.gameObject.name;
                hasColorBeenChanged = true;
            }
        }
    }

    private void OnTriggerExit(Collider exit)
    {
        if (hasColorBeenChanged)
        {
            if(exit.transform.gameObject.tag == "ColorCube" && exit.transform.gameObject.name == newColor)
            {
                Debug.Log("Trigger Exit Detected!"); // Add this debug log
                transform.parent.gameObject.GetComponent<Renderer>().material = StartingColor;
                target.GetComponent<Renderer>().material = TargetStartingColor;
                hasColorBeenChanged = false;
            }
        }
    }

    public string SaveMaterial()
    {
        string tempColor;
        tempColor = transform.parent.gameObject.GetComponent<Renderer>().material.name.ToString().Split("")[0];
        return tempColor;
    }
}

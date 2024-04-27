using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDown : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            GetComponent<SaveData>().DataSaving();
        }
    }
}

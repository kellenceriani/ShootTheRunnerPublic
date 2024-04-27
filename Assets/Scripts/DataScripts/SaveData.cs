using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public void DataSaving()
    {
        float tempTime = GetComponent<Timer>().FinalTime();
        string destination = Application.persistentDataPath + "/"
            + System.DateTime.UtcNow.ToLocalTime().ToString("M-d-yy-HH-mm") + ".txt";

        StreamWriter writer = new StreamWriter(destination, true);

        writer.Write("Total time: ");
        writer.Write(tempTime);

        writer.Close();
    }
}

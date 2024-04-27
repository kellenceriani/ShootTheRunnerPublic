using UnityEngine;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private GameObject enemyColorTrigger;
    [SerializeField] private GameObject weaponColorTrigger;
    [SerializeField] private GameObject aquaCube, blackCube, greenCube, orangeCube, purpleCube, redCube, yellowCube;
    [SerializeField] private Transform enemyControl, weaponControl;

    private string currentEnemyMat;
    private string currentWeaponMat;

    private GameData gd;

    private string path = "";

    private void Start()
    {
        path = Application.persistentDataPath + "/save.json";
        if (File.Exists(path))
        {
            LoadData();
        }
    }

    public void BeginShutdown()
    {
        GetComponent<SaveData>().DataSaving();
        SaveData();
    }
    private void SaveData()
    {
        GatherMaterials();
        CreateDataToSave();

        string json = JsonUtility.ToJson(gd);
        StreamWriter writer = new StreamWriter(path);
        writer.Write(json);
        writer.Close();

        Application.Quit();
    }

    private void GatherMaterials()
    {
        currentEnemyMat = enemyColorTrigger.GetComponent<UIColorTracker>().SaveMaterial();
        currentWeaponMat = weaponColorTrigger.GetComponent<UIColorTracker>().SaveMaterial();
    }
    private void CreateDataToSave()
    {
        gd = new GameData(currentEnemyMat, currentWeaponMat);
    }

    public void LoadData()
    {
        StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        gd = JsonUtility.FromJson <GameData>(json);
        currentEnemyMat = gd.Enemy;
        currentWeaponMat = gd.Weapon;

        LoadMaterials();
    }

    private void LoadMaterials()
    {
        if (currentEnemyMat != "Lit")
        {
            switch (currentEnemyMat)
            {
                case "Aqua":
                    aquaCube.transform.position = enemyControl.position;
                    break;
                case "Black":
                    blackCube.transform.position = enemyControl.position;
                    break;
                case "Green":
                    greenCube.transform.position = enemyControl.position;
                    break;
                case "Orange":
                    orangeCube.transform.position = enemyControl.position;
                    break;
                case "Purple":
                    purpleCube.transform.position = enemyControl.position;
                    break;
                case "Red":
                    redCube.transform.position = enemyControl.position;
                    break;
                case "Yellow":
                    yellowCube.transform.position = enemyControl.position;
                    break;

            }
        }

        if (currentWeaponMat != "Lit")
        {
            switch (currentWeaponMat)
            {
                case "Aqua":
                    aquaCube.transform.position = weaponControl.position;
                    break;
                case "Black":
                    blackCube.transform.position = weaponControl.position;
                    break;
                case "Green":
                    greenCube.transform.position = weaponControl.position;
                    break;
                case "Orange":
                    orangeCube.transform.position = weaponControl.position;
                    break;
                case "Purple":
                    purpleCube.transform.position = weaponControl.position;
                    break;
                case "Red":
                    redCube.transform.position = weaponControl.position;
                    break;
                case "Yellow":
                    yellowCube.transform.position = weaponControl.position;
                    break;

            }
        }

    }
}

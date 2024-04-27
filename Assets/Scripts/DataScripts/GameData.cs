using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string Enemy;
    public string Weapon;

    public GameData(string enemy, string weapon)
    {
        this.Enemy = enemy;
        this.Weapon = weapon;
    }
}

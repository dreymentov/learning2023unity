using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemLoadAndSave : MonoBehaviour
{
    public Vector3 playerPos3system;
    public float speedLS;
    public Color matShpereLS; 

    public void ToSaveJSON()
    {
        PlayerData playerData = new PlayerData();
        playerData.playerPos3 = GetComponent<Sphere>().player.transform.position;
        playerData.speedPD = GetComponent<Sphere>().speed;

        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(Application.dataPath + "/PlayerDataFile.json", json);
    }

    public void LoadFromJSON()
    {
        string json = File.ReadAllText(Application.dataPath + "/PlayerDataFile.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        playerPos3system = data.playerPos3;
        speedLS = data.speedPD;
        matShpereLS = data.matSpherePD;
    }
}

using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemLoadAndSave : MonoBehaviour
{
    public Vector3 playerPos3system;
    public float speedLS;
    public Color matShpereLS;

    public Inventory inventoryPlayer;

    public int slotForSave; // сохраняет кол-во слотов
    public int slotsForSave; // сохраняет слоты

    public Transform itemsInUI;

    public List<PotionData> listPD;

    public List<string> CheckSavedStrings;
    public List<string> CheckSavedStrings1;

    private string json;

    public void ToSaveJSON()
    {
        PlayerData playerData = new PlayerData();
        playerData.playerPos3 = GetComponent<Sphere>().player.transform.position;
        playerData.speedPD = GetComponent<Sphere>().speed;

        CheckSavedStrings.Clear();

        for (int i = 0; i < inventoryPlayer.items.Count; i++ )
        {
            CheckSavedStrings.Add(inventoryPlayer.items[i].name); 
        }

        playerData.itemNames = CheckSavedStrings;

        json = JsonUtility.ToJson(playerData, true);

        PlayerPrefs.SetString("jsonSave", json);

        //File.WriteAllText(Application.dataPath + "/PlayerDataFile.json", json);
    }

    public void LoadFromJSON()
    {
        //json = File.ReadAllText(Application.dataPath + "/PlayerDataFile.json");

        Debug.Log("Trying loading from PlayerPrefs");
        json = PlayerPrefs.GetString("jsonSave");

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log("tried");

        playerPos3system = data.playerPos3;
        speedLS = data.speedPD;
        CheckSavedStrings1 = data.itemNames;

        inventoryPlayer.items.Clear();

        for (int i = 0; i < CheckSavedStrings1.Count; i++)
        {
            foreach(PotionData itemPD in listPD)
            {
                if (CheckSavedStrings1[i] == itemPD.name)
                {
                    inventoryPlayer.items.Add(itemPD);
                }
            }
        }
    }

    public void Start()
    {
        LoadFromJSON();
        Save();
    }

    public void Save()
    {
        itemsInUI.GetComponent<InventoryWindow>().DestroyLogos();
        itemsInUI.GetComponent<InventoryWindow>().Redraw();
        Debug.Log(json);
    }

    public void Load()
    {

    }
}

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

    public PotionData fromPotionId0;
    public PotionData fromPotionId1;
    public PotionData fromPotionId2;
    public PotionData fromPotionId3;
    public PotionData fromPotionId4;

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

    public void Start()
    {
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("SavedSlot", inventoryPlayer.items.Count);

        for (int i = 0; i < inventoryPlayer.items.Count; i++)
        {
            PlayerPrefs.SetInt("SavedSlots" + i, inventoryPlayer.items[i].idPotion);
        }
    }

    public void Load()
    {
        slotForSave = PlayerPrefs.GetInt("SavedSlot");

        inventoryPlayer.items.Clear();

        for (int i = 0; i < slotForSave; i++)
        {
            int slotSetItem = PlayerPrefs.GetInt("SavedSlots" + i);

            if (slotSetItem == 0)
            {
                inventoryPlayer.items.Add(fromPotionId0);
            }
            if (slotSetItem == 1)
            {
                inventoryPlayer.items.Add(fromPotionId1);
            }
            if (slotSetItem == 2)
            {
                inventoryPlayer.items.Add(fromPotionId2);
            }
            if (slotSetItem == 3)
            {
                inventoryPlayer.items.Add(fromPotionId3);
            }
            if (slotSetItem == 4)
            {
                inventoryPlayer.items.Add(fromPotionId4);
            }
        }
    }
}

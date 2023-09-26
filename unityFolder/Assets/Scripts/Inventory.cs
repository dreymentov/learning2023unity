using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<PotionData> StartItems = new List<PotionData>();

    public  List<PotionData> InventoryItems = new List<PotionData>();

    void Start()
    {
        for (var i = 0; i < StartItems.Count; i++)
        {
            AddItem(StartItems[i]);
        }
    }

    public void AddItem(PotionData Potion)
    {
        InventoryItems.Add(Potion);
    }
}

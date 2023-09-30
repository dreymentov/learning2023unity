using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] public Sprite[] slots;

    public List<PotionData> items = new List<PotionData>();

    private void Start()
    {
        AddItemCycl();
    }

    public void AddItemToInventory(PotionData item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item.icon;
                return;
            }
        }
    }

    public void AddItemCycl()
    {
        for (int i = 0; i < items.Count; i++)
        {
            AddItemToInventory(items[i]);
        }
    }
}

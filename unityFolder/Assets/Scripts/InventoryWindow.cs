using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] Inventory targetInventory;
    [SerializeField] RectTransform itemsPanel;

    // Start is called before the first frame   update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Redraw()
    {
        for (var i = 0; i < targetInventory.InventoryItems.Count; i++)
        {
            var item = targetInventory.InventoryItems[i];

            var icon = new GameObject(name: "Icon");
            icon.AddComponent<Image>().sprite = item.Icon;
        }

    }
}

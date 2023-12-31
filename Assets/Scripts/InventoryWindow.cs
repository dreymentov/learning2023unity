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
        Redraw();
    }

    // Update is called once per frame
    public void Redraw()
    {
        for (var i = 0; i < targetInventory.slots.Length; i++)
        {
            var item = targetInventory.items[i];

            var icon = new GameObject(name: "Icon");

            icon.transform.parent = itemsPanel;
            icon.AddComponent<Image>().sprite = item.Icon;
        }
    }

    public void DestroyLogos()
    {
        foreach(Transform child in itemsPanel)
        {
            Destroy(child.gameObject);
        }
    }
}

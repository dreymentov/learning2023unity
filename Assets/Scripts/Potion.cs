using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private PotionData potionData; // 1

    private void OnMouseDown() // 2
    {
        Debug.Log(potionData.name); // 3
        Debug.Log(potionData.Description); // 3
        Debug.Log(potionData.Icon.name); // 3
        Debug.Log(potionData.GoldCost); // 3
    }
}

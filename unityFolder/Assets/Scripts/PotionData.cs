using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PotionData", menuName = "Potion Data", order = 51)]

public class PotionData : ScriptableObject
{
    [SerializeField]
    public string potionName;
    [SerializeField]
    public string description;
    [SerializeField]
    public Sprite icon;
    [SerializeField]
    public int goldCost;
    [SerializeField]
    public int idPotion;

    public string PotionName
    {
        get
        {
            return potionName;
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

    public int GoldCost
    {
        get
        {
            return goldCost;
        }
    }
}

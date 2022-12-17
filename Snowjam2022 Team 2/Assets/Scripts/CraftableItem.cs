using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class CraftableItem
{
    public enum ItemType
    {
        Material,
        Tool,
        Upgrade,
        Consumeable
    }
    public List<string> requiredMaterials;
    public string itemName;
    public ItemType itemType;
}


    /*
namespace Project.End
{
    [CreateAssetMenu(menuName = "Data/CraftableItemData")]
    public class CraftableItemData : ScriptableObject
    {
        public enum ItemType
        {
            Tool,
            Upgrade,
            Consumeable
        }
        public Dictionary<string, int> requiredMaterials;
        public string itemName;
        public ItemType itemType;
    }
}*/
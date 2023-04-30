using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DUFE.Inventory
{
    [Serializable]
    [CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObject/InventoryItem", order = 100)]
    public class InventorySlotSO : ScriptableObject
    {
        public string itemName;
        public float itemValue;
        public List<string> tags;
        public Sprite icon;


    }
}
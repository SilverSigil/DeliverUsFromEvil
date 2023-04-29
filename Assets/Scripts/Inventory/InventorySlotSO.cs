using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DUFE.Inventory
{
    [Serializable]
    public class InventorySlotSO
    {
        public string itemName;
        public float itemValue;
        public List<string> tags;
        public Sprite icon;


    }
}
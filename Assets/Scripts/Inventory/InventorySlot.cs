using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DUFE.Inventory
{

    public class InventorySlot:MonoBehaviour
    {
        public string itemName;
        public float  itemValue;
        public List<string> tags; 
        public Sprite icon;

        public InventorySlot(string itemName, Sprite icon, List<string> tags, float itemValue)
        {
            this.itemName = itemName;
            this.icon = icon;
            this.itemValue = itemValue;
            this.tags = tags;
        }
    }
}

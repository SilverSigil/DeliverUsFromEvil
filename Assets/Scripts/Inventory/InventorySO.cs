using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DUFE.Inventory
{
    [Serializable]
    [CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObject/Inventory", order = 100)]
    public class InventorySO : ScriptableObject
    {
        public List<InventorySlotSO> inventoryItems;

    }

}
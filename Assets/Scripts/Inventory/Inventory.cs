using DUFE.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DUFE.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [Header("Default Inventory List")]
        public InventorySO inventoryList;
        [Header("Current inventory")]
        public List<InventorySlotSO> items = new List<InventorySlotSO>();

        [Header("Prefab InventorySlot")]
        public GameObject itemSlot;
        [Header("Scene reference")]
        public GameObject parentInventory;

        public void Start()
        {
            if (inventoryList != null)
            {
                foreach (InventorySlotSO item in inventoryList.inventoryItems)
                {
                    addItem(item);
                    InventorySlot g = generateInventorySlot(item);
                }
            }
        }

        public InventorySlot generateInventorySlot(InventorySlotSO inventorySlot)
        {
            GameObject g = Instantiate(itemSlot, parentInventory.transform);
            g.GetComponent<InventorySlot>().itemName = inventorySlot.itemName; 
            g.GetComponent<InventorySlot>().icon = inventorySlot.icon;
            g.GetComponent<InventorySlot>().tags = inventorySlot.tags;
            g.GetComponent<InventorySlot>().itemValue = inventorySlot.itemValue;
            g.transform.Find("name").GetComponent<TextMeshProUGUI>().text = inventorySlot.itemName;
            g.transform.Find("icon").GetComponent<Image>().sprite = inventorySlot.icon;
            return g.GetComponent<InventorySlot>(); 
        }

        public void addItem(InventorySlotSO inventorySlot)
        {
            items.Add(inventorySlot);
        }

        public void removeItem(InventorySlotSO inventorySlot)
        {
            items.Remove(inventorySlot);
        }


        internal void addItemAndGenerate(InventorySlotSO item)
        {
            items.Add(item);
            generateInventorySlot(item);
        }
    }

}
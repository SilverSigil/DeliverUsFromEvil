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
        public List<InventorySlot> items = new List<InventorySlot>();
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
                    InventorySlot g = generateInventorySlot(item);
                    addItem(g);
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

        public void addItem(InventorySlot inventorySlot)
        {
            items.Add(inventorySlot);
        }

        public void removeItem(InventorySlot inventorySlot)
        {
            items.Remove(inventorySlot);
        }

    }

}
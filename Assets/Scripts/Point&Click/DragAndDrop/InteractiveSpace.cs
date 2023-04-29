using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DUFE.PointAndClick.Drag
{

public class InteractiveSpace : MonoBehaviour, IDropHandler
    {
        public new string tag;
        public string value;
        public UnityEvent onInteract;
        public TextMeshProUGUI test; 
        public string lastInventorySlot; 

        void Start()
        {

        }

        public void OnDrop(PointerEventData eventData)
        {

            Debug.Log("OnDrop");

            if (eventData.pointerDrag != null)
            {
            }
        }

        internal void Interact(Inventory.InventorySlot inventorySlot)
        {
            lastInventorySlot = inventorySlot.itemName;
            getLastInventorySlot();
            onInteract?.Invoke();
        }

        ///for debug
        ///
        public void getLastInventorySlot()
        {
            test.text = "last interaction with " + lastInventorySlot;
        }
    }

}
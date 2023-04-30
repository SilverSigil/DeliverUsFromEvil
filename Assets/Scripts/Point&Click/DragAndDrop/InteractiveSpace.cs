using DUFE.Core;
using DUFE.Inventory;
using SerializableDictionary.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DUFE.PointAndClick.Drag
{

public class InteractiveSpace : MonoBehaviour, IDropHandler, IINteractable
    {
        [Header("Item target for the outcome")]
        [SerializeField] 
        private List<InventorySlotSO> itemTarget = new List<InventorySlotSO>();
        private Dictionary<InventorySlotSO, bool> activatedItems = new Dictionary<InventorySlotSO, bool>(); 
        [Space()]
        [Header("Event on item drop")]
        public UnityEvent interactEvent;
        private bool outcomeReached = false; 

        void Start()
        {
            foreach(InventorySlotSO s in itemTarget)
            {
                activatedItems.Add(s, false);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {

            Debug.Log("OnDrop");

            if (eventData.pointerDrag != null)
            {
            }
        }

        internal bool OnInteract(Inventory.InventorySlot inventorySlot)
        {
            ///If we find it, we can asssume it's an object that's supposed to create an outcome
            if (itemTarget.Where(x => x.itemName == inventorySlot.itemName).Count() != 0)
            {
                InventorySlotSO s = itemTarget.Where(x => x.itemName == inventorySlot.itemName).First();
                activatedItems[s] = true;
                if (outcomeReached == false && (activatedItems.Where(x => x.Value == false).Count() == 0))
                {
                    outcomeReached = false;
                    Debug.Log("outcome reached");
                    FindAnyObjectByType<SceneManager>().addObjective(GetComponent<Objective>());
                    interactEvent?.Invoke();
                    return true;
                } else if (outcomeReached == false)
                {
                    return true;
                } else
                {

                    return false;
                }
            } else
            {
                return false; 
            }
        }

        public void OnInteract()
        {
            Debug.Log("interaction");
        }
    }

}
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
        private InventorySlotSO itemTarget;
        [Space()]
        [Header("Event on item drop")]
        public UnityEvent interactEvent;

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

        internal bool OnInteract(Inventory.InventorySlot inventorySlot)
        {
            ///If we find it, we can asssume it's an object that's supposed to create an outcome
            if(itemTarget.itemName == inventorySlot.itemName)
            {
                Debug.Log("outcome reached");
                FindAnyObjectByType<SceneManager>().addObjective(GetComponent<Objective>());
                interactEvent?.Invoke();
                return true; 
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
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
        public string value;
        [Header("List of event per item")]
        [SerializeField] private SerializableDictionary<InventorySlotSO, UnityEvent> itemDictionary;
        [Space()]
        [Header("Event on item drop")]
        public UnityEvent interactEvent;
        public TextMeshProUGUI test; 

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

        internal void onInteract(Inventory.InventorySlot inventorySlot)
        {
            ///We look for the value
            ///If we find it, we can asssume it's an object that's supposed to create an outcome
            if(itemDictionary.Dictionary.Keys.Where(x=>x.itemName == inventorySlot.itemName).First() != null)
            {
                FindAnyObjectByType<SceneManager>().addObjective(GetComponent<Objective>()); 
            }
            interactEvent?.Invoke();
        }

        public void onInteract()
        {
            Debug.Log("interaction");
        }
    }

}
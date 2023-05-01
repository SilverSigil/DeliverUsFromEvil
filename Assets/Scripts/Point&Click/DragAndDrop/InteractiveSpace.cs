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
        [Header("Is the interaction part of a chain actions ? \nObjective will not be added")]
        public bool partOfChainAction = false;
        [Header("Needed Objectives to allow interaction")]
        public List<Objective> objectiveNeeded = new List<Objective>(); 
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
            bool objective = false; 
            ///If we find it, we can asssume it's an object that's supposed to create an outcome
            if (itemTarget.Where(x => x.itemName == inventorySlot.itemName).Count() != 0)
            {
                InventorySlotSO s = itemTarget.Where(x => x.itemName == inventorySlot.itemName).First();
                activatedItems[s] = true;

                //We check if there's objectives needed for the interaction to happen 
                if(objectiveNeeded.Count > 0)
                {
                    objective = checkObjective();
                } else
                {
                    objective = true; 
                }
                if (outcomeReached == false && (activatedItems.Where(x => x.Value == false).Count() == 0) && (objective== true))
                {
                    FindObjectOfType<Inventory.Inventory>().removeItem(s);
                    outcomeReached = false;
                    Debug.Log("outcome reached");
                    if(partOfChainAction == true)
                    {

                    } else
                    {
                        FindAnyObjectByType<SceneManager>().addObjective(GetComponent<Objective>());
                    }
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

        private Objective checkObjective()
        {

           SceneManager sm = FindAnyObjectByType<SceneManager>();
            Objective c = null; 
            foreach(Objective a in objectiveNeeded)
            {
                Objective testedObj = sm.objectives.Where(x => x.objectiveName == a.objectiveName).First(); 
                if (testedObj != null)
                {
                    c = testedObj;
                }
            }
            return c;
        }

        public void OnInteract()
        {
            Debug.Log("interaction");
        }
    }

}
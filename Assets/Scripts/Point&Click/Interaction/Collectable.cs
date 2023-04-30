using DUFE.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collectable interactive 2d object. 
/// </summary>
public class Collectable : MonoBehaviour, IINteractable
{
    public InventorySlotSO item; 

    public void onInteract()
    {
        FindObjectOfType<Inventory>().addItem(item);
    }

}

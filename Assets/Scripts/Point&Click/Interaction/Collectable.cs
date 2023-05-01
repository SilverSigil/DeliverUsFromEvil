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

    public void OnInteract()
    {
        Inventory i = FindObjectOfType<Inventory>();
        if (i.items.Count <= 5)
        {
            FindObjectOfType<Inventory>().addItemAndGenerate(item);
            Destroy(gameObject);
        } else
        {

        }
    }

}

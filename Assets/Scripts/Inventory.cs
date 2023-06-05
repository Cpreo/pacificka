using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{

    public static event Action<List<InventoryItem>> OnInventoryChange;
    public static List<InventoryItem> inventory = new List<InventoryItem>(12);

    Vector3 mini;
    Vector3 max;
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    private void OnEnable() {
        DontDestroyOnLoad(gameObject);

        PortraitPiece.OnPieceCollected += Add;
        Chest.OnChestCollected += Add;
        Hedge_Interact.OnRecieveShear += Add;
        Pickup.OnItemCollected += Add;
        duct_interact.OnRecieveDuct += Add;
        CabinetKeyInteract.OnRecieveKey += Add;
        CabinetMatchboxInteract.OnRecieveBox += Add;
        Fridge.OnRecieveNote += Add;
        Fridge_Interact.OnRecieveSoup += Add;
        Garden_Shed.OnRecieveShearBlade += Add;
        Garden_Shed.OnRecieveShearHandle += Add;
    }
    private void OnDisable() {

        PortraitPiece.OnPieceCollected -= Add;
        Chest.OnChestCollected -= Add;
        Hedge_Interact.OnRecieveShear -= Add;
        Pickup.OnItemCollected -= Add;
        duct_interact.OnRecieveDuct -= Add;
        CabinetKeyInteract.OnRecieveKey -= Add;
        CabinetMatchboxInteract.OnRecieveBox -= Add;
        Fridge.OnRecieveNote -= Add;
        Fridge_Interact.OnRecieveSoup -= Add;
        Garden_Shed.OnRecieveShearBlade -= Add;
        Garden_Shed.OnRecieveShearHandle -= Add;
    }
    public void Add(ItemData itemData) {
        if(itemDictionary.TryGetValue((itemData), out InventoryItem item)) {
            return;
        }
        else {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added {itemData.displayName} to the inventory");
            OnInventoryChange?.Invoke(inventory);
        }
    }
    public void Remove(ItemData itemData) {
    
        InventoryItem newItem = new InventoryItem(itemData);
        List<InventoryItem> toRemove = new List<InventoryItem>();
        foreach(InventoryItem oldItem in inventory)
        {
            if(itemData.displayName ==  oldItem.itemData.displayName)
            {
                toRemove.Add(oldItem);
            }
        }
        foreach (InventoryItem removable in toRemove)
        {
            inventory.Remove(removable);
        }
        inventory.Remove(newItem);
        itemDictionary.Remove(itemData);
        OnInventoryChange?.Invoke(inventory);
        Debug.Log(inventory.Contains(newItem));
        /* if(itemDictionary.TryGetValue((itemData), out InventoryItem item)) {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Remove(newItem);
            itemDictionary.Remove(itemData);
            OnInventoryChange?.Invoke(inventory);
        } */
        /* else 
        {
            

        } */
    }

   


}

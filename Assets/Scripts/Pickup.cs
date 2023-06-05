using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Collectable
{
    public static event HandleItemCollected OnItemCollected;
    public delegate void HandleItemCollected(ItemData itemData);
    public ItemData item_data;
    public ItemData combine_data;

    protected override void OnCollect() {
        if(collected == false) {
        OnItemCollected?.Invoke(item_data);
        base.OnCollect();
        }

    }
    protected override void Update() {
        
        foreach(InventoryItem item in Inventory.inventory){
                {
                    if(combine_data != null){
                    if(combine_data.displayName ==  item.itemData.displayName||item_data.displayName ==  item.itemData.displayName)
                    {
                        Destroy(gameObject);
                    }
                    } else {
                        if(item_data.displayName ==  item.itemData.displayName)
                        {
                        Destroy(gameObject);
                        }
                    }
                }
            }
        base.Update();
    }
}

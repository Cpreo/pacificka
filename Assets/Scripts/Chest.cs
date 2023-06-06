using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public Sprite emptyChest;
    public ItemData chest_data;
    private bool collected;
    
    public static event HandleChestOpened OnChestCollected;
    public delegate void HandleChestOpened(ItemData itemData);
    
    protected override void Start(){
    base.Start();
    foreach(InventoryItem item in Inventory.inventory){
                {
                    if(chest_data.displayName ==  item.itemData.displayName)
                    {
                        Destroy(gameObject);
                    }
                }
            }
   }
    protected override void Interact() {
        if(Input.GetKeyDown(key)){
        if(!activated) {
            bool contain1 = false;
            if(requiredItem != null) {

                    foreach(InventoryItem item in Inventory.inventory)
                    {
                    if(requiredItem.displayName ==  item.itemData.displayName)
                    {
                        contain1 = true;

                    }
                }
                Debug.Log(requiredItem);
                
            
            }
            if(requiredItem == null) {
                    contain1 = true;
            }
            if(!contain1) {
                    base.Interact();
                    return;
            }
                if(contain1){
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                if(chest_data !=  null ) {
                    
                    GameManager.instance.ShowText("You recieved a " +chest_data.displayName + "!",25,Color.yellow,GameManager.instance.player.transform.position, Vector3.up *50,3f);
                    if(collected == false)
                    {
                    OnChestCollected?.Invoke(chest_data);
                    }
                    collected = true;
                    
                }
                }
                
             }
             
            
        }
        
        
        base.Interact();

    }


    /*
    protected override void OnCollect(){

        if(!collected) {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + pesosAmount + "pesos!",25,Color.yellow,transform.position, Vector3.up *50,3f);
            Debug.Log("Grant Money!");
        }
        base.OnCollect();
        if(collected) {
            Debug.Log("Money Taken");
        }
       
    }
    */
}

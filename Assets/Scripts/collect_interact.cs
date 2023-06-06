using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect_interact : Interactable
{
    public ItemData collectable;
    public static event HandleCollectableRecieved OnRecieveCollect;
    public delegate void HandleCollectableRecieved(ItemData itemData);
    protected override void Interact() {
        if(Input.GetKeyDown(key)){
            if(!activated){
            OnRecieveCollect?.Invoke(collectable);
            }
        }
        base.Interact();
    }
}

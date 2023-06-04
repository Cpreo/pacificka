using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Interactable : Interactable
{
    // Start is called before the first frame update
    public GameObject interactImagePrefab;
    public GameObject canvas;
    GameObject slideshow;
    public Sprite finImage;
    bool displaying = false;
    public ItemData interact_item;
    void Awake(){
        foreach(InventoryItem item in Inventory.inventory){
                {
                    if(interact_item.displayName ==  item.itemData.displayName)
                    {
                       GetComponent<SpriteRenderer>().sprite = finImage;
                    }
                }
            }
        canvas = GameObject.FindWithTag("Canvas");
    }
  protected override void Interact() {
        
        if(!activated) {

             if(Input.GetKeyDown(key) && displaying == false){
                
             slideshow = Instantiate(interactImagePrefab);
             displaying = true;
             slideshow.transform.SetParent(canvas.transform,false);
             }
            
        }

    }
    protected override void Update() {
        if(displaying) {
        if(slideshow.GetComponent<Interact_Controller>().finished == true)
        {
            GetComponent<SpriteRenderer>().sprite = finImage;
        }
        
        }
        base.Update();
    }
}

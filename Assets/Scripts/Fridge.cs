using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable
{
    bool activated2;
    public GameObject interactImagePrefab;
    public GameObject canvas;
    GameObject slideshow;
    public Sprite finImage;
    bool displaying = false;
    public string denial_fridge;
    public string accept_fridge;
    public static event HandleNoteRecieved OnRecieveNote;
    public delegate void HandleNoteRecieved(ItemData itemData);
    bool initialMessage = false;
    Player ourPlayer;
    // Update is called once per frame
    public ItemData Note;
    public ItemData rolling_data;

    void Awake(){
        canvas = GameObject.FindWithTag("Canvas");
        
    }
    protected override void Interact() {
        if(ourPlayer.typing){
            return;
        }
        if(Input.GetKeyDown(key)){
            foreach(InventoryItem item in Inventory.inventory)
                {
                    if(rolling_data.displayName ==  item.itemData.displayName)
                    {  
                        activated2 = true;
                    }
                }
        if(activated2 == true) {
            DisplayText(accept_fridge);
        }
        else {
            if(initialMessage){
            DisplayText(denial_fridge);
            }
        }
        }
        base.Interact();
        
        if(activated) {
            OnRecieveNote?.Invoke(Note);
        if(Input.GetKeyDown(key)){
                if(activated2 && displaying == false){
                        
                    slideshow = Instantiate(interactImagePrefab);
                    displaying = true;
                    slideshow.transform.SetParent(canvas.transform,false);
                }
                if(activated){
                    initialMessage = true;
                foreach(InventoryItem item in Inventory.inventory)
                {
                    if(rolling_data.displayName ==  item.itemData.displayName)
                    {  
                        activated2 = true;
                    }
                }
                    

                }
                    

             }
        }
    }
    protected override void Update() {
        if(ourPlayer == null){
        ourPlayer = GameManager.instance.player.GetComponent<Player>();
        }
        if(displaying) {
        if(slideshow.GetComponent<Interact_Controller>().finished == true)
        {
            GetComponent<SpriteRenderer>().sprite = finImage;
        }
        
        }
        base.Update();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractable : Interactable
{

    public bool puzzleBeaten;
    // Start is called before the first frame update
    public Sprite finishedPortrait;
    // Update is called once per frame
    bool containsItem = false;

    public void Interact2() {

        Interact();
    }
    protected override void Interact()   
    {
        if(Input.GetKeyDown(key)){
            if(activated == false) {
            InventoryItem invRequired = new InventoryItem(requiredItem);
            List<InventoryItem> toRemove = new List<InventoryItem>();
            foreach(InventoryItem oldItem in Inventory.inventory)
            {
            if(requiredItem.displayName ==  oldItem.itemData.displayName)
            {
                containsItem = true;
            }
            }

            if(!containsItem){
                DisplayText(denialText);
                return;
            }
            if(!puzzleBeaten) {
                DisplayText("The portrait fits in, but i'ts still too dark to see.");
                activated = true;
                GetComponent<SpriteRenderer>().sprite = finishedPortrait;
            }
            if(puzzleBeaten) {
                DisplayText(FlavorText);
                activated = true;
                GetComponent<SpriteRenderer>().sprite = finishedPortrait;
            }
            
            
            
            Debug.Log("Huzzah!");
            } else if (activated == true){
                activated = false;

            }

        }
    }
    protected override void Update(){
        base.Update();
        if(GameObject.Find("Global Light").GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity > 0.4f){
            puzzleBeaten = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Minimenu : MonoBehaviour
{
    // Start is called before the first frame update
    Button combine;
    Button inspect;
    public GameObject DialogueBox;
    public InventorySlot selected;
    protected virtual void DisplayText(string selectedText){

        if(selectedText.Length > 0)
            {
                string[] diaText;
                diaText = DialogueBox.GetComponent<Dialogue>().lines;
                diaText[0] = selectedText;
                DialogueBox.SetActive(true);
            }

    }
    void Awake()
    {
        inspect = gameObject.transform.Find("Inspect").GetComponent<Button>();
        combine = gameObject.transform.Find("Combine").GetComponent<Button>();
        combine.onClick.AddListener(Combine);
        inspect.onClick.AddListener(Inspect);
        GameObject holder = GameObject.FindWithTag("DialogueBox");
        Transform[] trs = holder.GetComponentsInChildren<Transform>(true);
         foreach(Transform t in trs){
         if(t.name == "DialogueBox"){
              DialogueBox = t.gameObject;
         }
        }
    }
    void Combine() {
        if(!InventorySlot.isCombining){
        InventorySlot.isCombining = true;

        } else {
            InventorySlot.isCombining = false;
        }
    }
    void Inspect() {
        
        //DialogueBox = GameObject.FindGameObjectWithTag("DialogueBox");
        selected = InventorySlot.selectedSlots[0]; // can get through parent
        GameObject slot = transform.parent.gameObject;
        InventoryManager invManager =slot.GetComponentInParent<InventoryManager>();
        
        int index = invManager.inventorySlots.IndexOf(selected);
        if(index >= Inventory.inventory.Count){
            return;
        }
        DisplayText(Inventory.inventory[index].inspectText);
        //TBD
    }

    public InventoryItem getSelectedItem(InventorySlot selectSlot) {
        InventorySlot ourSlot = selectSlot;// can get through parent
        GameObject slot = transform.parent.gameObject;
        InventoryManager invManager =slot.GetComponentInParent<InventoryManager>();
        
        int index = invManager.inventorySlots.IndexOf(ourSlot);
        if(index >= Inventory.inventory.Count || index == -1){
            return null;
        }
        return Inventory.inventory[index];
    }

    void Craft() {
        ItemData ouritem = getSelectedItem(InventorySlot.selectedSlots[0]).itemData;
        List<ItemData> combineList = ouritem.combinesWith;
        int items = ouritem.combinesWith.Count;
        foreach(InventorySlot selectSlot in InventorySlot.selectedSlots) {
            if(getSelectedItem(selectSlot)== null)
            {
                return;
            }
            ItemData selectedData = getSelectedItem(selectSlot).itemData;
            if(combineList.Contains(selectedData))
            {
                items -= 1;
            }
        }
        if(items == 0) {
            GameObject InventoryObject = GameObject.FindGameObjectWithTag("Inventory");
            Inventory inv = InventoryObject.GetComponent<Inventory>();
            inv.Add(ouritem.combinesInto);

            foreach(ItemData item in combineList) {
                inv.Remove(item);
                
            

            InventorySlot.selectedSlots.Clear();
            }
            inv.Remove(ouritem);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(InventorySlot.isCombining) {
            Craft();
        }
    }
}

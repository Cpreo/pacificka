using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetKeyInteract : MonoBehaviour
{
    int state = 0;
    public Sprite opened_cabinet;
    public Sprite empty_cabinet;
    public ItemData fish_shaped_key;
    public Button cabinet_door;
    public Button Key;
    public static event HandleKeyRecieved OnRecieveKey;
    public delegate void HandleKeyRecieved(ItemData itemData);
    public void Awake() {
        cabinet_door = gameObject.transform.Find("Drawer").GetComponent<Button>();
        cabinet_door.onClick.AddListener(ClickCabinet);
        Key = gameObject.transform.Find("Key").GetComponent<Button>();
        Key.onClick.AddListener(ClickKey);
    }
    public void ClickCabinet() {
        if(state == 0){
            state =1;
            gameObject.GetComponent<Image>().sprite = opened_cabinet;
           

        }

    }
     public void ClickKey() {

        if(state == 1){
            state =2;
            gameObject.GetComponent<Image>().sprite = empty_cabinet;
            OnRecieveKey?.Invoke(fish_shaped_key);

        }

    }
    // Update is called once per frame
    void Update()
    {
        if(state ==2){
            gameObject.GetComponent<Interact_Controller>().finished = true;
            if(Input.GetMouseButtonDown(0)){
                
                gameObject.SetActive(false);
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetMatchboxInteract : MonoBehaviour
{
    int state = 0;
    public Sprite opened_cabinet;
    public Sprite empty_cabinet;
    public ItemData match_box;
    public Button cabinet_door;
    public Button MatchBox;
    public static event HandleBoxRecieved OnRecieveBox;
    public delegate void HandleBoxRecieved(ItemData itemData);
    public void Awake() {
        cabinet_door = gameObject.transform.Find("Drawer").GetComponent<Button>();
        cabinet_door.onClick.AddListener(ClickDrawer);
        MatchBox = gameObject.transform.Find("Match Box").GetComponent<Button>();
        MatchBox.onClick.AddListener(ClickMatchBox);
    }
     void ClickDrawer() {
        if(state == 0){
            state =1;
            gameObject.GetComponent<Image>().sprite = opened_cabinet;
        }
    }
     void ClickMatchBox() {
        Debug.Log("Clicked");
        if(state == 1){
            state =2;
            gameObject.GetComponent<Image>().sprite = empty_cabinet;
            OnRecieveBox?.Invoke(match_box);

        }

    }
    void Update()
    {
        if(state ==2){
            gameObject.GetComponent<Interact_Controller>().finished = true;
            if(Input.GetMouseButtonDown(0)){
                
                gameObject.SetActive(false);
                
            }
        }
    }
    // Update is called once per frame
}

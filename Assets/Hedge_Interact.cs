using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Hedge_Interact : MonoBehaviour
{
    // Start is called before the first frame update
    int state = 0;
    public Sprite sheared_hedge;
    public ItemData shear_item;
    public Button shear;
    public static event HandleShearRecieved OnRecieveShear;
    public delegate void HandleShearRecieved(ItemData itemData);
    public void Awake() {
        shear = gameObject.transform.Find("Shear").GetComponent<Button>();
        shear.onClick.AddListener(ClickShear);
    }
    public void ClickShear() {
        Debug.Log("Clicked");

        if(state == 0){
            state =1;
            gameObject.GetComponent<Image>().sprite = sheared_hedge;
            OnRecieveShear?.Invoke(shear_item);

        }

    }
    // Update is called once per frame
    void Update()
    {
        if(state ==1){
            gameObject.GetComponent<Interact_Controller>().finished = true;
            if(Input.GetMouseButtonDown(0)){
                
                gameObject.SetActive(false);
                
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Fridge_Interact : MonoBehaviour
{
    // Start is called before the first frame update
    int state = 0;
    public Sprite empty_fridge;
    public ItemData fish_stew;
    public Button Soup;
    public static event HandleSoupRecieved OnRecieveSoup;
    public delegate void HandleSoupRecieved(ItemData itemData);
    public void Awake() {
        Soup = gameObject.transform.Find("Soup").GetComponent<Button>();
        Soup.onClick.AddListener(ClickSoup);
    }
    public void ClickSoup() {
        Debug.Log("Clicked");

        if(state == 0){
            state =1;
            gameObject.GetComponent<Image>().sprite = empty_fridge;
            OnRecieveSoup?.Invoke(fish_stew);

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

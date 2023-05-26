using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class duct_interact : MonoBehaviour
{
// Start is called before the first frame update
    int state = 0;
    public Sprite no_tape_crate;
    public ItemData tape_item;
    public Button duct_tape;
    public static event HandleDuctRecieved OnRecieveDuct;
    public delegate void HandleDuctRecieved(ItemData itemData);
    public void Awake() {
        duct_tape = gameObject.transform.Find("Duct Tape").GetComponent<Button>();
        duct_tape.onClick.AddListener(ClickTape);
    }
    public void ClickTape() {
        Debug.Log("Clicked");

        if(state == 0){
            state =1;
            gameObject.GetComponent<Image>().sprite = no_tape_crate;
            OnRecieveDuct?.Invoke(tape_item);
            duct_tape.gameObject.SetActive(false);
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

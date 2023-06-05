using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Garden_Shed : MonoBehaviour
{
    int state = 0;
    public Sprite empty_shed;
    public ItemData sblade;
    public ItemData shandle;
    public Button shear_blade;
    public Button shear_handle;
    public static event HandleShearBladeRecieved OnRecieveShearBlade;
    public delegate void HandleShearBladeRecieved(ItemData itemData);
    public static event HandleShearHandleRecieved OnRecieveShearHandle;
    public delegate void HandleShearHandleRecieved(ItemData itemData);
    public void Awake() {
        shear_blade = gameObject.transform.Find("Shear Blade").GetComponent<Button>();
        shear_handle = gameObject.transform.Find("Shear Handle").GetComponent<Button>();
        shear_blade.onClick.AddListener(ClickBlade);
        shear_handle.onClick.AddListener(ClickHandle);
    }
    public void ClickBlade() {      
        state +=1;
        OnRecieveShearBlade?.Invoke(sblade);
        
        gameObject.transform.Find("Shear Blade").GetComponent<Image>().enabled = false;
        Debug.Log("Shear Blade");
    }
    public void ClickHandle() {

        state +=1;
        OnRecieveShearHandle?.Invoke(shandle);
        gameObject.transform.Find("Shear Handle").GetComponent<Image>().enabled = false;
        shear_handle.gameObject.SetActive(false);
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

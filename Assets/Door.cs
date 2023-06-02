using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    // Start is called before the first frame update

    public string sceneName;
    bool activated2;
    // Update is called once per frame
    protected override void Interact() {

        base.Interact();
        
        if(activated) {
            
        if(Input.GetKeyDown(key)){
                if(activated2){
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
                }
                if(activated)
                    activated2 = true;

             }
        }
    }
}

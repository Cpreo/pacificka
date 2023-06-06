using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class Torch : Interactable
{
    public Animator animator;
    private UnityEngine.Rendering.Universal.Light2D myLight;
    

    protected override void Start()
    {
    myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    animator = GetComponent<Animator>();
    // light is initially off

    // test comment
    
    myLight.enabled = false;
    base.Start();
    }
    protected override void Interact(){
        Debug.Log("Test");
        base.Interact();
        
        if(activated == true) {
            animator.SetBool("Activated", true);
            if(soundEffect != null)
                    {
                    soundEffect.Play();
                    }
        }
        if(activated == false) {
            animator.SetBool("Activated", false);
        }
        
        myLight.enabled = activated;
    }
    protected override void Update() {
        if(activated == true) {
            animator.SetBool("Activated", true);
        }
        base.Update();
    }
}

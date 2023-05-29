using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

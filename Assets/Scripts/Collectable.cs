using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
 //Logic
    protected bool collected;
    public string item;
    public AudioSource soundEffect;
    
    protected override void Start() {
        base.Start();
        boxCollider.isTrigger = true;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player"){
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        
        if(item.Length > 0 && collected == false) {
                    if(soundEffect != null)
                    {
                    soundEffect.Play();
                    }
                    GameManager.instance.ShowText("You picked up a " +item + "!",25,Color.red,transform.position, Vector3.up *50,3f);
                    GameManager.instance.Inventory.Add(item);
                    item = "";

                }
        collected = true;
        gameObject.SetActive(false);
    }
}

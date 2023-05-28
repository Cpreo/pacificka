using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public GameObject DialogueBox;
    public float moveSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        GameObject holder = GameObject.FindWithTag("DialogueBox");
        Transform[] trs = holder.GetComponentsInChildren<Transform>(true);
         foreach(Transform t in trs){
         if(t.name == "DialogueBox"){
              DialogueBox = t.gameObject;
         }
         }
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        Move();
    }
    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX,moveY);
    }
    void Move() {

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    void Update()
    {
        ProcessInputs();
        if(GameManager.instance.player ==  null) {
            GameManager.instance.player = this;
        }
        if( DialogueBox.GetComponent<Dialogue>().typing){
            return;
        }

        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        // reset moveDelta
        moveDelta = new Vector3(x,y,0);
        // Swap sprite direction based on etc
        if(moveDelta.x > 0) {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0) {
            transform.localScale = new Vector3(-1,1,1);
        }
       /*  hit= Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));
        // Make sure we can move in this direction, by casting a box there first
        if(hit.collider == null || hit.collider.isTrigger)
        {

            transform.Translate(0,moveDelta.y * Time.deltaTime,0);
        }
        hit= Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(moveDelta.x,0),Mathf.Abs(moveDelta.x * Time.deltaTime),LayerMask.GetMask("Actor","Blocking"));
        // Make sure we can move in this direction, by casting a box there first
        if(hit.collider == null|| hit.collider.isTrigger)
        {
            transform.Translate(moveDelta.x * Time.deltaTime,0,0);
        } */
    }
}

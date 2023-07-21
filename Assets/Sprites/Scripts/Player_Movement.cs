using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    //Speed
    public float moveSpeed;

    //RigidBody
    public Rigidbody2D rigidBody;


    private Vector2 movementInput;
    public Animator anim;
    public int coinscount, healthpoints;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);


    }

    //best for physics calculations
    private void FixedUpdate()
    {
        //makes out player move
        rigidBody.velocity = movementInput * moveSpeed;
    }


    private void OnMove(InputValue inputValue)
    {
        //WASD = vector 2 nvalues
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedPotion"))
        {
            Transform col = collision.transform;
            col.transform.position = new Vector2(999, 999);
        }
        if (collision.CompareTag("Coin"))
        {
            coinscount++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("HPPotion"))
        {
            Destroy(collision.gameObject);
        }
    }
}
//Basic WASD Movement of Player
//W
//if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow))
//{
//    anim.enabled = true;
//    anim.SetTrigger("BackwardAnimation");
//}


////A
//if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
//{
//    anim.enabled = true;
//    anim.SetTrigger("LeftAnimation");
//}


////S
//if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
//{
//    anim.enabled = true;
//    anim.SetTrigger("FrontAnimation");
//}


////D
//if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
//{
//    anim.enabled = true;
//    anim.SetTrigger("RightAnimation");
//}

//if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow))
//{
//    anim.enabled = false;
//}
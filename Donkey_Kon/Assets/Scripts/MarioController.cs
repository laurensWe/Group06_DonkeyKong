using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarioController : MonoBehaviour
{
    public float speed;
    bool facingRight = true;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // horizontal move
        float moveHorizontal = Input.GetAxis("Horizontal");

        // jump
        bool moveUp = Input.GetButton("Jump");
        float amountMoveUp;
        if (moveUp)
        {
            amountMoveUp = 2;
        }
        else
        {
            amountMoveUp = 0;
        }

        
        Vector2 movement = new Vector2(moveHorizontal, amountMoveUp);
        rb.AddForce(movement * speed);

        if(moveHorizontal>0 &&!facingRight)     //If the player moves right but is not facing right yet, flip the player
        {
            Flip();
        }
        else if(moveHorizontal<0 && facingRight) 
        {
            Flip();
        }

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;        //Get the local Scale
        theScale.x *= -1;                               //Flip the x axis
        transform.localScale = theScale;                //Apply the new local Scale
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarioController : MonoBehaviour
{
    public float movespeed;
    public float jumpHeight;

    bool facingRight = true;

    public Rigidbody2D rb;
    public bool onLadder;

    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    public Transform groundCheck;        
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        gravityStore = rb.gravityScale;         //Store gravity of player at initialization
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

 

    }
    void Update()
    {
        //Horizontal Movement
        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }

        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        // Flip
        if (Input.GetKey("right") == true && !facingRight)     //If the player moves right but is not facing right yet, flip the player
        {
            Flip();
        }
        else if (Input.GetKey("left") == true && facingRight)
        {
            Flip();
        }

        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        anim.SetBool("grounded", grounded);


        // Vertical movement on ladder
        if (onLadder)
        {
            //Physics2D.IgnoreCollision(rb.GetComponent<BoxCollider2D>,);

            rb.gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxis("Vertical");

            rb.velocity = new Vector2(rb.velocity.x, climbVelocity);
        }
        if (!onLadder)       // Reset gravity to normal when player gets off the ladder
        {
            rb.gravityScale = gravityStore;
        }
    }
    // Flips the player when changing direction
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;        //Get the local Scale
        theScale.x *= -1;                               //Flip the x axis
        transform.localScale = theScale;                //Apply the new local Scale
    }

}


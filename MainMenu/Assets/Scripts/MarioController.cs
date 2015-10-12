using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarioController : MonoBehaviour
{
    public float movespeed;
    public float jumpHeight;
    public AudioClip clip;
    bool facingRight = true;

    public Rigidbody2D rb;
    public bool onLadder;
    private bool vertbutton;
    private bool climbing;

    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    private Animator anim;

    private int scoreValue;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        gravityStore = rb.gravityScale;         //Store gravity of player at initialization

        vertbutton = false;
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
        // Jump and double Jump
        if (grounded)
        {
            doubleJumped = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
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

        //Animation
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        anim.SetBool("grounded", grounded);

        anim.SetBool("onLadder", onLadder);


        // Vertical movement on ladder
        if (onLadder && vertbutton)
        {

            rb.gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxis("Vertical");

            rb.velocity = new Vector2(0.7f * rb.velocity.x, climbVelocity);
        }
        if (!onLadder)       // Reset gravity to normal when player gets off the ladder
        {
            rb.gravityScale = gravityStore;
        }
        // Vertical movement through bar
        if (Input.GetKey("down") || Input.GetKey("up"))
            vertbutton = true;
        else vertbutton = false;

        if (onLadder && vertbutton)
        {
            climbing = true;
        }
        else
        {
            climbing = false;
        }

        var bars = GameObject.FindGameObjectsWithTag("BarWithLadder");
        foreach (var bar in bars)
            Physics2D.IgnoreCollision(rb.GetComponent<BoxCollider2D>(), bar.GetComponent<BoxCollider2D>(), climbing);
        var donkeybars = GameObject.FindGameObjectsWithTag("DonkeyBar");
        foreach (var bar in donkeybars)
            Physics2D.IgnoreCollision(rb.GetComponent<BoxCollider2D>(), bar.GetComponent<BoxCollider2D>(), climbing);
    }
    // Jump method
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        PlayMusic();
    }
    // Flips the player when changing direction
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;        //Get the local Scale
        theScale.x *= -1;                               //Flip the x axis
        transform.localScale = theScale;                //Apply the new local Scale
    }

    void PlayMusic()
    { 
        AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
    }
}


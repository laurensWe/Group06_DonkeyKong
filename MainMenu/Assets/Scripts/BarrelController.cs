using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour
{

    public float speed;
    public Vector2 direction;
    private Vector2 tempDirection;

    private Rigidbody2D rb;

    public Transform JumpCheck;
    public float JumpCheckRadius;

    public Animator anim;
    private int random;

    private bool onLadder;
    private bool onGround;

    private float Timer1;
    private float Timer2;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Timer1)      
        {
            random = Random.Range(1,10);  
            Timer1 = Time.time + 1;
     
        }

        // JumpCheck update
        if (JumpCheck != null)
        {
            JumpCheck.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.75f);

        }

        // ignore the jumpcheck collision
        var ladders = GameObject.FindGameObjectsWithTag("Ladder");
        foreach (var ladder in ladders)
            Physics2D.IgnoreCollision(JumpCheck.GetComponent<Collider2D>(), ladder.GetComponent<Collider2D>(), true);


        // with a chance of 50% the barrel wil go down the ladder.
        if (!onLadder)
        {
            rb.velocity = new Vector2(speed * direction.x, speed * direction.y);
            anim.SetBool("OnLadder", false);
            
            var ladderbars = GameObject.FindGameObjectsWithTag("BarWithLadder");
            foreach (var ladderbar in ladderbars)
                Physics2D.IgnoreCollision(rb.GetComponent<Collider2D>(), ladderbar.GetComponent<Collider2D>(), false);
        }
        else
        { 
            if (!onGround && random < 5)
            {
                
                if (Time.time > Timer2)
                {
                    anim.SetBool("OnLadder", true);
                    rb.velocity = new Vector2(speed*direction.x, speed* 0.001f * direction.y - 10);

                    var ladderbars = GameObject.FindGameObjectsWithTag("BarWithLadder");
                    foreach (var ladderbar in ladderbars)
                        Physics2D.IgnoreCollision(rb.GetComponent<Collider2D>(), ladderbar.GetComponent<Collider2D>(), true);

                    Timer2 = Time.time + 1;
                    direction.x = -1 * direction.x;
                }
                
            }
            else
            {
                anim.SetBool("OnLadder", false);
 
                rb.velocity = new Vector2(speed * direction.x, speed * direction.y);

                var ladderbars = GameObject.FindGameObjectsWithTag("BarWithLadder");
                foreach (var ladderbar in ladderbars)
                    Physics2D.IgnoreCollision(rb.GetComponent<Collider2D>(), ladderbar.GetComponent<Collider2D>(), false);
            }
        }

        if(transform.position.y < -8){
            Destroy(gameObject);
        }

    }

    // checks if a trigger has entered the barrel collider
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("ChangeDirection"))
        {
            direction = new Vector2(-1 * direction.x, direction.y - 1f);

        }

        // Barrel reaches the end of the level
        if (other.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }

        // Barrel collides with mario
        if (other.CompareTag("Player"))
        {
            // play animation of death and open Game Over Menu. 
        }

        //Barrel collides with Ladder
        if (other.CompareTag("Ladder"))
        {
            onLadder = true;

        }   

    }

    // checks if a trigger has left the barrel collider
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Ladder"))
        {
            onLadder = false;

        }

    }

    // checks if a collider has entered the barrel collider
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bar"))
        {
            onGround = true;
        }
    }

    // checks if a collider has left the barrel collider
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bar"))
        {
            onGround = false;
        }
    }



}

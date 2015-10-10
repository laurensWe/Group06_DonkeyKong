using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {

    public float speed;
    public Vector2 direction;

    private Rigidbody2D rb;

    public Transform JumpCheck;
    public float JumpCheckRadius;
    public LayerMask PlayerLayer;

    public Animator anim;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

	}

    // Update is called once per frame
    void Update() {

            rb.velocity = new Vector2(speed * direction.x, speed * direction.y);
        if (JumpCheck != null)
        {
            JumpCheck.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.75f);
        }
	}

    void OnTriggerEnter2D(Collider2D other){


        if (other.CompareTag("ChangeDirection"))
        {
            direction = new Vector2(-1 * direction.x, direction.y - 0.5f);

        }

        // Barrel reaches the end of the level
        if(other.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }

        // Barrel collides with mario
        if(other.CompareTag("Player"))
        {
            // play animation of death and open Game Over Menu. 
        }
        
        // Barrel collides with Ladder
       // if(other.CompareTag("Ladder"))
       // {
            // with a probability of 50 % barrel will go down the ladder.
           // if(Random.Range(0,1) < 0.5)
           // {
               // anim.SetBool("OnLadder", true);
               // rb.velocity = new Vector2(speed * rb.position.x, speed * direction.y);

           // }

       // }

        //anim.SetBool("OnLadder", false);
    }
 
}

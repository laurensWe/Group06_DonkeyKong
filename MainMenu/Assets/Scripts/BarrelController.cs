using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {

    public float speed;
    public Vector2 direction;
    private int scoreValue = 10;

    private Rigidbody2D rb;

    public Transform JumpCheck;
    public float JumpCheckRadius;
    public LayerMask PlayerLayer;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();

	}

    // Fixed update is used when we work with physics.
    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(JumpCheck.position, JumpCheckRadius, PlayerLayer))
        {
            ScoreManager.score += scoreValue;
        }
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = new Vector2(speed * direction.x, speed * direction.y);

        JumpCheck.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.75f);

	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("ChangeDirection"))
        {
            direction = new Vector2(-1 * direction.x, direction.y - 1);

        }
        if (other.CompareTag("DestroyBar"))
        {
            // should be implemented, does not work at the moment.
            //DestroyImmediate(gameObject);
        }
    }

    
}

using UnityEngine;
using System.Collections;

public class BarrelController : MonoBehaviour {

    public float speed;
    public Vector2 direction;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

	}

    // Update is called once per frame
    void Update() {
        rb.velocity = new Vector2(speed * direction.x, speed * direction.y);

	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("ChangeDirection"))
        {
            direction = new Vector2(-1 * direction.x, direction.y);

        }
    }
}

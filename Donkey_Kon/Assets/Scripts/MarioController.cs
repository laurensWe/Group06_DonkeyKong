using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MarioController : MonoBehaviour
{
    public float speed;

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
            amountMoveUp = 1;
        }
        else
        {
            amountMoveUp = 0;
        }

        // 
        Vector2 movement = new Vector2(moveHorizontal, amountMoveUp);
        rb.AddForce(movement * speed);

    }
}

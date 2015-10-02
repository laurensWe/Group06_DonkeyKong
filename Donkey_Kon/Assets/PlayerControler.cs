using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // horizontal move
        float moveHorizontal = Input.GetAxis("Horizontal");

        // jump
        bool moveUp = Input.GetButton("Jump");
        float amountMoveUp;
        if (moveUp)
        { 
            amountMoveUp = 3;
        }
        else
        {
            amountMoveUp = 0;
        }

        // 
        Vector2 movement = new Vector2 (moveHorizontal,amountMoveUp);

    }
}

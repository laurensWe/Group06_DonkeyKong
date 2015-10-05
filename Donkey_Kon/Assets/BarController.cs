using UnityEngine;
using System.Collections;
public class BarController : MonoBehaviour {

    private MarioController thePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<MarioController>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (thePlayer.onLadder)
        {
            
            Physics2D.IgnoreCollision(thePlayer.rb.GetComponent<BoxCollider2D>,GetComponent<BoxCollider2D>);
        }
    }
}

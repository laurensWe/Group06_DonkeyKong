using UnityEngine;
using System.Collections;

public class LadderController : MonoBehaviour {

    private MarioController thePlayer;

	// 
	void Start ()
    {
        thePlayer = FindObjectOfType<MarioController>();    // Search for object that has the script MarioController attached
	}
	
	
	void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thePlayer.onLadder = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thePlayer.onLadder = false;
        }
    }
}

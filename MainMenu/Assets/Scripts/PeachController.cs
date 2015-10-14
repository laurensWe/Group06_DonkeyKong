using UnityEngine;
using System.Collections;

public class PeachController : MonoBehaviour {
    public int ScoreKeeper;
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            
            // play animation that you'll receive points
            Destroy(gameObject);
            ScoreKeeper = ScoreManager.score;
            Application.LoadLevel("Game_Won");

        }
    }
}

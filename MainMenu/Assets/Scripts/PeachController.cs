using UnityEngine;
using System.Collections;
using System;

public class PeachController : MonoBehaviour {

    public int ScoreKeeper;
    private bool GameWon;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();    
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            // play animation that you'll receive points
            //Destroy(gameObject);
            ScoreKeeper = ScoreManager.score;
            //StartCoroutine("wait");

            GameWon = true;
        }
    }


    void Update()
    {
        anim.SetBool("GameWon", GameWon);
        if (GameWon==true)
        {
            StartCoroutine("wait");
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        Application.LoadLevel("Game_Won");
        
    }
}

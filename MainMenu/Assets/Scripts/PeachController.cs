﻿using UnityEngine;
using System.Collections;
using System;

public class PeachController : MonoBehaviour {

    private bool GameWon;
    private Animator anim;
    private bool PlayedMusic = false;

    public ParticleSystem fireworks1;
    public ParticleSystem fireworks2;
    public ParticleSystem fireworks3;
    public AudioClip firebang;
    public String nextScene;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();    
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // first compare highscore
            if (ScoreManager.score > ScoreManager.highScore)
            {
                PlayerPrefs.SetInt("highScore", ScoreManager.score);
            }
            PlayerPrefs.SetInt("currentScore", ScoreManager.score);

            GameWon = true;
        }
    }


    void Update()
    {
        anim.SetBool("GameWon", GameWon);
        if (GameWon==true){
            PlayMusic();
            fireworks1.Play();
            fireworks2.Play();
            fireworks3.Play();
            StartCoroutine("wait");
        }
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(2);
        Application.LoadLevel(nextScene);  
    }

    void PlayMusic()
    {
        if(PlayedMusic == false)
        {
            AudioSource.PlayClipAtPoint(firebang, new Vector3(5, 1, 2));
            PlayedMusic = true;
        }
        
    }
}

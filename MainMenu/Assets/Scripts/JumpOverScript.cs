﻿using UnityEngine;
using System.Collections;
using System;
using System.Diagnostics;

public class JumpOverScript : MonoBehaviour
{
    public int scoreValue;
    Stopwatch stopWatch = new Stopwatch();

    // Use this for initialization
    void Start()
    {

    }
        
    void OnTriggerEnter2D(Collider2D other)
    {
         
        if (other.CompareTag("Player"))
        {    
            ScoreManager.score += scoreValue;
            // play animation that you'll receive points
        }
    }
}
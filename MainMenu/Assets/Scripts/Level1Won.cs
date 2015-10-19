using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Level1Won : MonoBehaviour
{
    public Text scoreTextBetween;

	// Use this for initialization
	void Start () {
    scoreTextBetween.text = "Currentscore = " + PlayerPrefs.GetInt("currentScore");
        StartCoroutine("wait");
    }
	
	// Update is called once per frame
	void Update () {

    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel("level2");
    }
}

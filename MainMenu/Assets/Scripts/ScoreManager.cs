using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int score;
    public static int highScore;

    public Text scoreText;
    public Text highScoreText;

	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("currentScore");
        if (PlayerPrefs.HasKey("highScore"))
        {
            Debug.Log("has key");
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else
        {
           Debug.Log("has no key");
           highScore = 0;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(highScore);
        scoreText.text = "Score: " + score;
        highScoreText.text = "Highscore: " + highScore;
    }


}

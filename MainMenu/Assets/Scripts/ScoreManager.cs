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
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = "Highscore: " + highScore;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
	}
}

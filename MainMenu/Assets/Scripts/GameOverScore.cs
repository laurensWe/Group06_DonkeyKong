using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour {

    public Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText.text ="Score: " + PlayerPrefs.GetInt("currentScore");

        if(PlayerPrefs.GetInt("highScore") == PlayerPrefs.GetInt("currentScore"))
        {
            // play animation highscore
            // Activate Sprite you won the highscore
        }
    }
}

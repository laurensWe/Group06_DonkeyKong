using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {
    public Text HighScore;

    public void Update()
    {
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("highScore");
    }
}

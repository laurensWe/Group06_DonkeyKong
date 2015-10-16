using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Game is Quiting");
        Application.Quit();
    }

    public void StartGame()
    {
        Application.LoadLevel("level1");
    }

    public void ResetHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", 0);
        }
    }
}


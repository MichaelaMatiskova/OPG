using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;

    public void Update()
    {
        scoreText.text = "Score: " + Score.scoreValue;
    }

    public static void RestartButton()
    {
        SceneManager.LoadScene("Snake"); 
    }

    public static void ExitButton()
    {
        Application.Quit();
    }
}

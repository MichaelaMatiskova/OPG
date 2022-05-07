using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //[SerializeField] 
    public GameObject pauseMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();  
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public static void ExitButton()
    {
        Application.Quit();
    }

    public void ToStart()
    {
        SceneManager.LoadScene("StartTitle");
        Time.timeScale = 1f;
    }
}

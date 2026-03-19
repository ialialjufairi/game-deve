using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); // Make sure the scene is spelled exactly "Game"
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
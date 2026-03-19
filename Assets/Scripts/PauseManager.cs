using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseButton; // Top-left pause button
    public GameObject pauseMenu;   // Panel with Resume/Quit buttons

    void Start()
    {
        // Ensure UI initial state
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f; // Make sure game is running
    }

    // Called by PauseButton
    public void PauseGame()
    {
        pauseMenu.SetActive(true);    // Show the menu
        pauseButton.SetActive(false); // Hide pause button
        Time.timeScale = 0f;          // Stop game
    }

    // Called by ResumeButton
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);   // Hide menu
        pauseButton.SetActive(true);  // Show pause button
        Time.timeScale = 1f;          // Resume game
    }

    // Called by QuitButton
    public void QuitGame()
    {
        Time.timeScale = 1f;          // Resume before quitting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
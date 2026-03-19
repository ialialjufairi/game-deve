using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startButton;   // Start Game button
    public GameObject player;        // Player object
    public GameObject groundSpawner; // Ground spawner
    public GameObject pauseButton;   // Top-left pause button
    public GameObject quitButton;

    void Start()
    {
        // At first, only Start button is visible
        startButton.SetActive(true);
        player.SetActive(false);
        groundSpawner.SetActive(false);
        pauseButton.SetActive(false); // Hide pause at start
    }

    public void StartGame()
    {
        // Hide Start button
        startButton.SetActive(false);

        // Show game objects
        player.SetActive(true);
        groundSpawner.SetActive(true);
        pauseButton.SetActive(true); // Show pause now
        quitButton.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Game is exiting...");
        Application.Quit();
    }

}
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject PauseMenuPanel;
    
    private bool isPaused = false;
    public GameObject pauseButton;
    public int score = 0;
    private void Start()
    {
        InvokeRepeating("increaseScore", 1f, 1f);
        if (PauseMenuPanel != null)
            PauseMenuPanel.SetActive(false);
        if (pauseButton != null)
            pauseButton.SetActive(true); // make sure it’s visible on start
    }


    private void Update()
    {
        // Press Esc (PC) or Pause button (mobile) to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }


    public void PauseGame()
    {
        if (PauseMenuPanel != null)
            PauseMenuPanel.SetActive(true);

        if (pauseButton != null)
            pauseButton.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (PauseMenuPanel != null)
            PauseMenuPanel.SetActive(false);
        if (pauseButton != null)
            pauseButton.SetActive(true); // show pause button again
        Time.timeScale = 1f; // Resume normal time
        isPaused = false;
    }
    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void increaseScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Resume time in case the game is paused
        SceneManager.LoadScene("MainMenu"); // your main menu scene name here
    }

}

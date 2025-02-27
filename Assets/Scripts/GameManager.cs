using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for scene management

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText; // Reference to the timer text object
    public float gameTime = 30f; // Total game time in seconds (30 seconds)
    private float currentTime; // Current time remaining
    private int score;
    private bool gameOver = false;
    public TextMeshProUGUI gameOverText;

  void Start()
  {
    score = 0;
    currentTime = gameTime; 
    UpdateTimerText();
        
    }

    void Update()
    {
        if (!gameOver)
        {
            currentTime -= Time.deltaTime;

            Debug.Log("Time: " + currentTime); // ADDED DEBUG LINE

            if (currentTime <= 0)
            {
                currentTime = 0; // Prevents timer from going negative
                GameOver();
            }

            UpdateTimerText();
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    void UpdateTimerText()
    {
        int seconds = Mathf.FloorToInt(currentTime);
        timerText.text = seconds.ToString("00"); 
    }

    public void GameOver()
    {
          gameOverText.gameObject.SetActive(true);

        gameOver = true;
        Debug.Log("Game Over!");
        // Display Game Over Screen
        //Stop spawning of packets

        //Stop the player form moving

        // Implement loading your game over screen scene.
        SceneManager.LoadScene("GameOverScene"); // Replace "GameOverScene" with the actual scene name
    }
}
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for scene management

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Static instance for easy access
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText; // Reference to the timer text object
    public float gameTime = 30f; // Total game time in seconds (30 seconds)
    private float currentTime; // Current time remaining
    private int score;
    private bool gameOver = false;
    public TextMeshProUGUI gameOverText;

    public PlayerController playerController; // Reference to the PlayerController

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        score = 0;
        currentTime = gameTime;
        UpdateTimerText();

        // Find the PlayerController in the scene (assuming there's only one)
        playerController = FindObjectOfType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene!  Make sure it exists.");
        }

    }

    void Update()
    {
        if (!gameOver)
        {
            currentTime -= Time.deltaTime;

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
        if (scoreText != null) // Add this null check
        {
            scoreText.text = "Score: " + score;
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null) // Add this null check
        {
            int seconds = Mathf.FloorToInt(currentTime);
            timerText.text = seconds.ToString("00");
        }
    }

     public void GameOver()
    {
        if(gameOverText != null) // Added so test works
             gameOverText.gameObject.SetActive(true);

        gameOver = true;
        Debug.Log("Game Over!");

        // Stop Player Movement
        if (playerController != null)
        {
            playerController.enabled = false; // Disable the PlayerController script instead of calling StopMoving()
        }

    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
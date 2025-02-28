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

    private PlayerController playerController; // Reference to the PlayerController

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
        scoreText.text = "Score: " + score;
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
        gameOverText.gameObject.SetActive(true);
        gameOver = true;

        // Stop Player Movement
        if (playerController != null)
        {
            playerController.StopMoving();
        }

        // Implement loading your game over screen scene.
        SceneManager.LoadScene("GameOverScene"); // Replace "GameOverScene" with the actual scene name
    }

        public bool IsGameOver()
    {
        return gameOver;
    }
}
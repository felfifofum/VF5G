using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public float gameTime = 30f;
    private float currentTime;
    private int score;
    private bool gameOver = false;
    public TextMeshProUGUI gameOverText;

    // Static instance for easy access from other scripts
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    void Start()
    {
        score = 0;
        currentTime = gameTime;
        UpdateTimerText();
        gameOverText.gameObject.SetActive(false); // Hide game over text at start

    }

    void Update()
    {
        if (!gameOver)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
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
        gameOverText.gameObject.SetActive(true); //show game over screen
        gameOver = true;
        Time.timeScale = 0f; // Pause the game
        Debug.Log("Game Over!");
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText; 
    public float gameTime = 30f; 
    private float currentTime; 
    private int score;
    private bool gameOver = false;
    public TextMeshProUGUI gameOverText;

    public PlayerController playerController; 

    public UIMenuManager uiMenuManager; 

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

        playerController = FindObjectOfType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene!  Make sure it exists.");
        }

         uiMenuManager = FindObjectOfType<UIMenuManager>();

        if (uiMenuManager == null)
        {
          Debug.LogError("UIMenuManager not found in the scene!  Make sure it exists.");
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
        if (scoreText != null) 
        {
            scoreText.text = "Score: " + score;
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null) 
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
            playerController.enabled = false; 
        }

        if (uiMenuManager != null)
        {
            uiMenuManager.ShowGameOverButtons();
        }
    }

    public bool IsGameOver()
    {
        return gameOver;
    }
}
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
        Time.timeScale = 1f;
        score = 0;
        currentTime = gameTime;
        UpdateTimerText();  //Call the timer text to ensure that it works and starts correctly
        gameOverText.gameObject.SetActive(false); // Hide game over text at start
    }

    // Add a public Initialize() method
    public void Initialize(TextMeshProUGUI scoreText, TextMeshProUGUI timerText)
    {
        this.scoreText = scoreText;
        this.timerText = timerText;
    }

    void Start()
    {
        // Do nothing here.  Initialization is handled in Initialize()
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
        if (timerText == null) //CRUCIAL check
        {
            Debug.LogError("Timer text is null in UpdateTimerText!");
            return; //Exit to prevent errors
        }

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
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    public int score = 0;  // Current score

    public Text scoreText; // UI Text element to display score

    // Make sure to have score text element named `scoreText` in the Game View in your scene!
    private void Awake()
    {
        // Singleton pattern (ensures only one GameManager exists):
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate game managers
        }
    }

    // Method to add score
    public void AddScore(int points)
    {
        score += points;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

    }
}
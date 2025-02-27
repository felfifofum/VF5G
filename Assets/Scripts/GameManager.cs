using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  
    public TextMeshProUGUI scoreText; 
    private int score;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    score = 0;
    scoreText.text = "Score: " + score;

    UpdateScore(0);
    }

  // Update is called once per frame
  private void UpdateScore(int scoreToAdd)
  {
    score += scoreToAdd;
    scoreText.text = "Score: " + score;
  }
}

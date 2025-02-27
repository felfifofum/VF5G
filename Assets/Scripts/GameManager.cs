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

    }

  public void UpdateScore(int scoreToAdd)
{
    Debug.Log("UpdateScore called");
    score += scoreToAdd;
    scoreText.text = "Score: " + score;

}
}

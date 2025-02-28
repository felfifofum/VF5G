// using System.Collections;
// using NUnit.Framework;
// using UnityEngine;
// using UnityEngine.TestTools;
// using TMPro; // Import the TextMeshPro namespace

// public class GameOverTests
// {
//     [UnityTest]
//     public IEnumerator GameOverScreenAppearsAfterTimerEnds()
//     {
//         // 1. Setup
       
//         GameObject gameManagerGameObject = new GameObject("GameManager");
//         GameManager gameManager = gameManagerGameObject.AddComponent<GameManager>();

//         GameObject gameOverTextGameObject = new GameObject("GameOverText");
//         TextMeshProUGUI gameOverText = gameOverTextGameObject.AddComponent<TextMeshProUGUI>();
//         gameOverText.gameObject.SetActive(false); // Ensure it starts hidden

       
//         gameManager.gameOverText = gameOverText;
//         gameManager.gameTime = 0f;

//         //Create a timer and score text
//         GameObject timerTextGameObject = new GameObject("TimerText");
//         TextMeshProUGUI timerText = timerTextGameObject.AddComponent<TextMeshProUGUI>();
//         gameManager.timerText = timerText;

//         GameObject scoreTextGameObject = new GameObject("ScoreText");
//         TextMeshProUGUI scoreText = scoreTextGameObject.AddComponent<TextMeshProUGUI>();
//         gameManager.scoreText = scoreText;

        
//         yield return new WaitForSeconds(0.1f);

//         // 2. Assert
//         // Verify that the gameOverText object is now active
//         Assert.IsTrue(gameManager.gameOverText.gameObject.activeSelf, "Game Over screen should be visible after the timer ends.");

//         // 3. Cleanup (Important for Test Stability!)
//         //Destroy the game object created
//         Object.Destroy(gameManagerGameObject);
//         Object.Destroy(gameOverTextGameObject);
//         Object.Destroy(timerTextGameObject);
//         Object.Destroy(scoreTextGameObject);
//     }
// }
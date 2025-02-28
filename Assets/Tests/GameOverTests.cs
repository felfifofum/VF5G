using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using TMPro;

public class GameOverTests
{
    [UnityTest]
    public IEnumerator GameOverScreenAppearsAfterTimerEnds()
    {
        // Arrange
        //Create GameObjects
        GameObject gameManagerGO = new GameObject("GameManager");
        GameManager gameManager = gameManagerGO.AddComponent<GameManager>();

        GameObject gameOverTextGO = new GameObject("GameOverText");
        gameOverTextGO.SetActive(false);
        TextMeshProUGUI gameOverText = gameOverTextGO.AddComponent<TextMeshProUGUI>();
        gameManager.gameOverText = gameOverText;

        gameManager.gameTime = 2f; // Set a short game time
        gameManager.scoreText = null;
        gameManager.timerText = null;
        GameManager.Instance = gameManager;

        GameObject vehicleGO = new GameObject("Vehicle");
        PlayerController playerController = vehicleGO.AddComponent<PlayerController>();
        gameManager.playerController = playerController;
        playerController.enabled = true;

        // Act
        yield return new WaitForSeconds(gameManager.gameTime + 0.1f); // Wait for the timer to end

        // Assert
        Assert.IsTrue(gameManager.gameOverText.gameObject.activeSelf, "Game over screen should be active");
        Assert.IsFalse(playerController.enabled, "Player movement should have stopped");


        //Teardown
        Object.Destroy(gameManagerGO);
        Object.Destroy(vehicleGO);
        GameManager.Instance = null;
    }
}
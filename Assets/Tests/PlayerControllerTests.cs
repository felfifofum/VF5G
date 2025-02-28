using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    private GameObject car;
    private PlayerController playerController;
    private GameObject gameManagerGO; // Keep track of the GameManager GameObject
    private GameManager gameManager; // Keep track of the GameManager component

    [SetUp]
    public void SetUp()
    {
        // Arrange
        car = new GameObject();
        playerController = car.AddComponent<PlayerController>();

        // Create GameManager GameObject and add GameManager component
        gameManagerGO = new GameObject("GameManager");
        gameManager = gameManagerGO.AddComponent<GameManager>();

        // Set the GameManager.Instance BEFORE the PlayerController tries to access it
        GameManager.Instance = gameManager;  // VERY IMPORTANT: Set the singleton instance

        // Explicitly set the scoreText and timerText to null to avoid errors during the test, it will not be called anyway.
        gameManager.scoreText = null;
        gameManager.timerText = null;
        gameManager.gameOverText = null;
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the car and GameManager after each test
        Object.Destroy(car);

        if (gameManagerGO != null) // Check if gameManagerGO is not null before destroying it
        {
            Object.Destroy(gameManagerGO);
        }

        GameManager.Instance = null; // Reset the singleton instance
    }

    [Test]
    public void TestCarMovesLeft()
    {
        // Arrange
        car.transform.position = Vector3.zero;

        // Act
        playerController.MoveLeft();

        // Assert
        Assert.AreEqual(new Vector3(-1, 0, 0), car.transform.position);
    }

    [Test]
    public void TestCarMovesRight()
    {
        // Arrange
        car.transform.position = Vector3.zero;

        // Act
        playerController.MoveRight();

        // Assert
        Assert.AreEqual(new Vector3(1, 0, 0), car.transform.position);
    }

    [Test]
    public void TestCarMovesForward()
    {
        // Arrange
        car.transform.position = Vector3.zero;

        // Act
        playerController.MoveForward();

        // Assert
        Assert.AreEqual(new Vector3(0, 0, 1), car.transform.position);
    }

    [Test]
    public void TestCarMovesBackward()
    {
        // Arrange
        car.transform.position = Vector3.zero;

        // Act
        playerController.MoveBackward();

        // Assert
        Assert.AreEqual(new Vector3(0, 0, -1), car.transform.position);
    }

    [UnityTest]
    public IEnumerator TestCarDoesNotMoveOutOfBoundsLeft()
    {

        // 7 is left boundary
        car.transform.position = new Vector3(-7, 0, 0);

        playerController.MoveLeft();
        yield return null;

        Assert.AreEqual(new Vector3(-7, 0, 0), car.transform.position);
    }

    [UnityTest]
    public IEnumerator TestCarDoesNotMoveOutOfBoundsRight()
    {
        // Arrange
        car.transform.position = new Vector3(7, 0, 0);

        // Act
        playerController.MoveRight();
        yield return null;

        // Assert
        Assert.AreEqual(new Vector3(7, 0, 0), car.transform.position);
    }
}
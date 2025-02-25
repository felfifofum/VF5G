using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    private GameObject car;
    private PlayerController playerController;

    [SetUp]
    public void SetUp()
    {
        car = new GameObject();
        playerController = car.AddComponent<PlayerController>();
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
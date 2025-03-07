using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    private GameObject car;
    private PlayerController playerController;
    private GameObject gameManagerGO;
    private GameManager gameManager;

    // Improved dirrection using DRY principles
    // Direction vectors defined once and all future modifications happen in one place
    private static readonly Vector3 Left = Vector3.left;
    private static readonly Vector3 Right = Vector3.right;
    private static readonly Vector3 Forward = Vector3.forward;
    private static readonly Vector3 Backward = Vector3.back;

    [SetUp]
    public void SetUp()
    {
        car = new GameObject();
        playerController = car.AddComponent<PlayerController>();

        gameManagerGO = new GameObject("GameManager");
        gameManager = gameManagerGO.AddComponent<GameManager>();

        GameManager.Instance = gameManager;

        gameManager.scoreText = null;
        gameManager.timerText = null;
        gameManager.gameOverText = null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(car);

        if (gameManagerGO != null)
        {
            Object.Destroy(gameManagerGO);
        }

        GameManager.Instance = null;
    }

    [Test]
    public void TestCarMovesLeft()
    {
        car.transform.position = Vector3.zero;

        playerController.Move(Left);

        Assert.AreEqual(new Vector3(-1, 0, 0), car.transform.position);
    }

    [Test]
    public void TestCarMovesRight()
    {
        car.transform.position = Vector3.zero;

        playerController.Move(Right);

        Assert.AreEqual(new Vector3(1, 0, 0), car.transform.position);
    }

    [Test]
    public void TestCarMovesForward()
    {
        car.transform.position = Vector3.zero;

        playerController.Move(Forward);

        Assert.AreEqual(new Vector3(0, 0, 1), car.transform.position);
    }

    [Test]
    public void TestCarMovesBackward()
    {
        car.transform.position = Vector3.zero;

        playerController.Move(Backward);

        Assert.AreEqual(new Vector3(0, 0, -1), car.transform.position);
    }

    [UnityTest]
    public IEnumerator TestCarDoesNotMoveOutOfBoundsLeft()
    {
        car.transform.position = new Vector3(-7, 0, 0);

        playerController.Move(Left);
        yield return null;

        Assert.AreEqual(new Vector3(-7, 0, 0), car.transform.position);
    }

    [UnityTest]
    public IEnumerator TestCarDoesNotMoveOutOfBoundsRight()
    {
        car.transform.position = new Vector3(7, 0, 0);

        playerController.Move(Right);
        yield return null;

        Assert.AreEqual(new Vector3(7, 0, 0), car.transform.position);
    }
}

using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using TMPro;

public class ScoreTests
{
    [UnityTest]
    public IEnumerator ScoreIncreasesOnFirstCollision()
    {
        
        GameObject gameManagerGO = new GameObject("GameManager");
        GameManager gameManager = gameManagerGO.AddComponent<GameManager>();

        GameObject scoreTextGO = new GameObject("ScoreText");
        scoreTextGO.transform.SetParent(gameManagerGO.transform); // Make it a child of the GameManager
        TextMeshProUGUI scoreText = scoreTextGO.AddComponent<TextMeshProUGUI>();

        GameObject timerTextGO = new GameObject("TimerText");
        timerTextGO.transform.SetParent(gameManagerGO.transform); // Make it a child of the GameManager
        TextMeshProUGUI timerText = timerTextGO.AddComponent<TextMeshProUGUI>();

        GameObject gameOverTextGO = new GameObject("gameOverText");
        TextMeshProUGUI gameOverText = gameOverTextGO.AddComponent<TextMeshProUGUI>();
        gameManager.gameOverText = gameOverText; //This is the line missing

        gameManager.Initialize(scoreText, timerText);

        gameManager.scoreText.text = "Score: 0";  // Or whatever initial value you expect

        //Vehicle with Collider
        GameObject vehicleGO = new GameObject("Vehicle", typeof(BoxCollider));
        PlayerController playerController = vehicleGO.AddComponent<PlayerController>();
        vehicleGO.tag = "Vehicle";
        Rigidbody vehicleRB = vehicleGO.AddComponent<Rigidbody>();
        vehicleRB.useGravity = false; //Disable gravity, so it does not fall
        vehicleRB.isKinematic = true; //Make sure test works

        //Datapacket
        GameObject dataPacketGO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        DataPacketPhysics dataPacketPhysics = dataPacketGO.AddComponent<DataPacketPhysics>();
        Rigidbody dataPacketRB = dataPacketGO.GetComponent<Rigidbody>();
        if (dataPacketRB == null)
        {
            dataPacketRB = dataPacketGO.AddComponent<Rigidbody>();
        }

        dataPacketRB.drag = 0.5f;  //Add drag
        dataPacketPhysics.scoreValue = 10; // Set a score value

        dataPacketGO.transform.position = new Vector3(0, 0, 0);
        vehicleGO.transform.position = new Vector3(0.1f, 0, 0); //Slight offset

        // Simulate for a longer time
        for (int i = 0; i < 10; i++)
        {
            Physics.Simulate(Time.fixedDeltaTime);
        }

        // Wait a frame to allow the collision to occur
        yield return null;

        //Assert
        Assert.AreEqual("Score: 10", gameManager.scoreText.text);

        //Teardown
        Object.Destroy(gameManagerGO);
        Object.Destroy(vehicleGO);
        Object.Destroy(dataPacketGO);
        Object.Destroy(gameOverTextGO);
    }
}
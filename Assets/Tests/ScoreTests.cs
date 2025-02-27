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
        // Arrange
        GameObject gameManagerGO = new GameObject("GameManager");
        GameManager gameManager = gameManagerGO.AddComponent<GameManager>();

        // Create a TextMeshProUGUI object and assign it to the scoreText field
        GameObject scoreTextGO = new GameObject("ScoreText");
        scoreTextGO.transform.SetParent(gameManagerGO.transform); //Make it a child of the GameManager
        TextMeshProUGUI scoreText = scoreTextGO.AddComponent<TextMeshProUGUI>();
        gameManager.scoreText = scoreText;

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
        dataPacketPhysics.scoreValue = 10; // Set a score value

        //Act
        dataPacketGO.transform.position = new Vector3(0, 0, 0);
        vehicleGO.transform.position = new Vector3(0.1f, 0, 0); //Slight offset

        Physics.Simulate(Time.fixedDeltaTime);
        // Wait a frame to allow the collision to occur
        yield return null;

        //Assert
        Assert.AreEqual("Score: 10", gameManager.scoreText.text);

        //Teardown
        Object.Destroy(gameManagerGO);
        Object.Destroy(vehicleGO);
        Object.Destroy(dataPacketGO);
    }
}
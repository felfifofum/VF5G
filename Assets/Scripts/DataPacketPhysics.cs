using UnityEngine;

public class DataPacketPhysics : MonoBehaviour
{
    private Rigidbody rb;
    private bool constraintsReleased = false;
    public int scoreValue = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Ensure initial rotation constraints are set
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!constraintsReleased && collision.gameObject.CompareTag("Vehicle") && collision.gameObject.GetComponent<PlayerController>())
        {
            // Release rotation constraints
            rb.constraints = RigidbodyConstraints.None;
            constraintsReleased = true;

            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                // Increase score.
                gameManager.UpdateScore(scoreValue);
            }

            Destroy(gameObject);
        }
    }
}
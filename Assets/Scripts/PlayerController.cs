using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private float leftBoundary = -7f;
    private float rightBoundary = 7f;
    private bool canMove = true; // Flag to control movement

    void Start()
    {

    }

    void Update()
    {
        // Check if the game is over before allowing movement
        if (GameManager.Instance != null && !GameManager.Instance.IsGameOver())
        {
            //Boundary Movement Restriction
            if (transform.position.x < leftBoundary)
            {
                transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > rightBoundary)
            {
                transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
            }

            //Player MOvement
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }
        else
        {
            horizontalInput = 0;
            forwardInput = 0;
        }
    }

    public void MoveLeft()
    {
        if (GameManager.Instance != null && transform.position.x > leftBoundary && !GameManager.Instance.IsGameOver())
        {
            transform.position += Vector3.left;
        }
    }

    public void MoveRight()
    {
        if (GameManager.Instance != null && transform.position.x < rightBoundary && !GameManager.Instance.IsGameOver())
        {
            transform.position += Vector3.right;
        }
    }

    public void MoveForward()
    {
        if (GameManager.Instance != null && !GameManager.Instance.IsGameOver())
        {
            transform.position += Vector3.forward;
        }
    }

    public void MoveBackward()
    {
        if (GameManager.Instance != null && !GameManager.Instance.IsGameOver())
        {
            transform.position += Vector3.back;
        }
    }
    public void StopMoving()
    {
        canMove = false; // Set the canMove flag to false to stop movement.
        speed = 0;       // Stop moving forwards by setting its speed to 0;
        turnSpeed = 0;     // stop turning by setting its turnSpeed to 0.
    }
}
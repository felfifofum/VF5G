using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private float leftBoundary = -7f;
    private float rightBoundary = 7f;
    private bool canMove = true; 

    void Update()
    {
        if (GameManager.Instance != null && !GameManager.Instance.IsGameOver())
        {
            ApplyBoundaryLimits();

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

    public void Move(Vector3 direction)
    {
        if (GameManager.Instance != null && !GameManager.Instance.IsGameOver())
        {
            Vector3 newPosition = transform.position + direction;

            newPosition.x = Mathf.Clamp(newPosition.x, leftBoundary, rightBoundary);

            transform.position = newPosition;
        }
    }

    public void StopMoving()
    {
        canMove = false;
        speed = 0;
        turnSpeed = 0;
    }

    private void ApplyBoundaryLimits()
    {
        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        }
    }
}

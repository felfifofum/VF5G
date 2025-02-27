using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private vars
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    private float leftBoundary = -7f;  
    private float rightBoundary = 7f; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Restrict player's position within the boundaries
        if (transform.position.x < leftBoundary)
        {
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > rightBoundary)
        {
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        }

        // Get the player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    public void MoveLeft()
    {
        if (transform.position.x > leftBoundary)
        {
          // Move left if within boundary
            transform.position += Vector3.left; 
        }
    }

    public void MoveRight()
    {
        if (transform.position.x < rightBoundary)
        {
            transform.position += Vector3.right; 
        }
    }

    public void MoveForward()
    {
        transform.position += Vector3.forward; 
    }

    public void MoveBackward()
    {
        transform.position += Vector3.back; 
    }
}
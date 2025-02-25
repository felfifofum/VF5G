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
        transform.position = new Vector3(-1, 0, 0); 
    }

    public void MoveRight()
    {
         transform.position = new Vector3(1, 0, 0); 
    }

        public void MoveForward()
    {
         transform.position = new Vector3(0, 0, 1); 
    }

        public void MoveBackward()
    {
         transform.position = new Vector3(0, 0, -1); 
    }
}
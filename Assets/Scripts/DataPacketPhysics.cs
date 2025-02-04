using UnityEngine;

public class DataPacketPhysics : MonoBehaviour
{
    private Rigidbody rb;
    private bool constraintsReleased = false; // To prevent multiple releases

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
        }
    }
}
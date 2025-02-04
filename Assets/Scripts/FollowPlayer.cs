using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    //Vehicle and camera moving at same time - jittery
    // Late updats after update method happens (after vehicle movea)
    void LateUpdate()
    {
        // Offeset camer behind player by adding to player's position 
        transform.position = player.transform.position + offset;
    }
}

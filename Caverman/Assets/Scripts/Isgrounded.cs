using UnityEngine;

public class Isgrounded : MonoBehaviour
{
    
    public bool grounded;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor") || other.CompareTag("climbable")) 
        {
            grounded = true;
        }
    }

    // Trigger event when the player's groundmask exits the ground collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Floor") || other.CompareTag("climbable"))
        {
            grounded = false;
            
        }
    }
    public bool getGrounded()
    {
        return grounded;

    }
}

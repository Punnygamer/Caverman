using UnityEngine;

public class isclimb : MonoBehaviour
{
    public bool climbable;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("climbable"))
        {
            climbable = true;
        }
    }

   
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("climbable"))
        {
            climbable = false;
            
        }
    }
    public bool getClimbable()
    {
        return climbable;
    }
}

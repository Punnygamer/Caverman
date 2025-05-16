using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("win");
            SceneManager.LoadScene(2);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Collider door;
    private string win = "win";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log(win);
            //SceneManager.LoadScene(win);
        }
    }
}

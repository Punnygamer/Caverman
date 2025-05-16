using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private double health=6;
    private bool hurting;
    private double damage=1;
    private double healing=0.25;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pointofinterest"))
        {
            hurting = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("climbable"))
        {
            hurting = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            SceneManager.LoadScene(3);
        }
        if (hurting) { health -= damage * Time.deltaTime; }
        else { health += healing * Time.deltaTime; }
    }
}

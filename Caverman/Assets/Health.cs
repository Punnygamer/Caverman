using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private double health;
    private int maxhealth = 6;
    private bool hurting;
    private double damage=1;
    private double healing=0.25;

    private void Start()
    {
        health = maxhealth;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pointofinterest"))
        {
            hurting = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("pointofinterest"))
        {
            hurting = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (health <= 0) 
        {
            SceneManager.LoadScene(3);
        }
        if (hurting) { health -= damage * Time.deltaTime; }
        else if (health<maxhealth) { health += healing * Time.deltaTime; }
    }
}

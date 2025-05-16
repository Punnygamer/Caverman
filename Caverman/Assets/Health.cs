using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    private double health;
    private int maxhealth = 6;
    private bool hurting;
    private double damage=1;
    private double healing=0.25;
    public int timelimit;
    private double counter = 1;
    [SerializeField] private TextMeshProUGUI Timedisplay;
    float healthPercent;
    float alpha;
    Color newColor;

    [SerializeField] private Image CODBLOOD;

    private void Start()
    {
        health = maxhealth;
        Timedisplay.text = ""+timelimit;
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
        if (health <= 0) 
        {
            SceneManager.LoadScene(3);
        }
        if (hurting)
        { 
            health -= damage * Time.deltaTime;
            healthPercent = (float)(health / maxhealth);
            alpha = 1f - healthPercent;
            newColor = CODBLOOD.color;
            newColor.a = Mathf.Clamp01(alpha);
            CODBLOOD.color = newColor;
        }
        else if (health<maxhealth&&!hurting) 
        {
            health += healing * Time.deltaTime;
            healthPercent = (float)(health / maxhealth);
            alpha = 1f - healthPercent;
            newColor = CODBLOOD.color;
            newColor.a = Mathf.Clamp01(alpha);
            CODBLOOD.color = newColor;
        }
        counter -= 1 * Time.deltaTime;
        if (counter < 0) 
        { 
            counter = 1;
            timelimit -= 1;
            Timedisplay.text = "" + timelimit;
            if (timelimit <= 0) 
            {
                health = -1000;
            }
        }
        
    }
}

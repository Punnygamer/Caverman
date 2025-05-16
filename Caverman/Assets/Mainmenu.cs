using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void playgame() 
    {
        SceneManager.LoadScene(1);
    }
    public void endgame() 
    {
        Application.Quit();
        Debug.Log("Game quit!");
    }
    public void menugame() 
    {
        SceneManager.LoadScene(0);
    }

    public void restart() 
    {

    }
}

using UnityEngine;
public class MazeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject Leftwall;

    [SerializeField]
    private GameObject Rightwall;

    [SerializeField]
    private GameObject Northwall;

    [SerializeField]
    private GameObject Southwall;

    [SerializeField]
    private GameObject Entropy;

    [SerializeField]
    private GameObject Endwall;

    [SerializeField]
    private GameObject Unvisted;

    public bool Visited = false;
    public bool HasEntropy = false;
    public bool HasEndwall = false;

    public int gridX;
    public int gridZ;

    void Start()
    {
        //Entropy.SetActive(false);
        //Endwall.SetActive(false);
    }

    public void Visit()
    {
        Visited = true;
        Unvisted.SetActive(false);
    }

    public void GainEntropy()
    {
        if (!HasEndwall)
        {
            HasEntropy = true;
            Entropy.SetActive(true);
            Debug.Log($"Entropy added to {gameObject.name}");
        }
    }

    public void GainEndwall()
    {
        if (HasEntropy == true)
        {
            HasEntropy = false;
            Entropy.SetActive(false);
        }
        
        HasEndwall = true;
        Endwall.SetActive(true);
    }

    //clear the walls
    public void Clearwall(int wall)
    {
        if (wall == 1)
        {
            Leftwall.SetActive(false);
        }
        else if (wall == 2)
        {
            Rightwall.SetActive(false);
        }
        else if (wall == 3)
        {
            Northwall.SetActive(false);
        }
        else if (wall == 4)
        {
            Southwall.SetActive(false);
        }
    }
    public void ClearNorth() { Northwall.SetActive(false); }
    public void ClearSouth() { Southwall.SetActive(false); }
    public void ClearRight() { Rightwall.SetActive(false); }
    public void ClearLeft() { Leftwall.SetActive(false); }
}

using UnityEngine;

//based on ketra games with the entropy and end wall being mine https://www.youtube.com/watch?v=_aeYq5BmDMg&t=112s


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
    public void ClearNorth() { Northwall.SetActive(false); }
    public void ClearSouth() { Southwall.SetActive(false); }
    public void ClearRight() { Rightwall.SetActive(false); }
    public void ClearLeft() { Leftwall.SetActive(false); }
}

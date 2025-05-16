using System.Collections.Generic;
using UnityEngine;

//based on ketra games with the entropy and end wall, spawning being mine. https://www.youtube.com/watch?v=_aeYq5BmDMg&t=112s



public class CaveGen : MonoBehaviour
{
    [SerializeField]
    private MazeCell Cavecells;

    public int xsize;
    public int zsize;
    public float cellsize = 1f;
    private MazeCell finalcell;
    [SerializeField] private GameObject playerpfab;
    [SerializeField] private int EntropyNum = 5;
    

    private MazeCell[,] cavegrid;

    void Start()
    {
        GenerateGrid();
        GenerateMaze(null, cavegrid[0, 0]);
        finalcell.GainEndwall();
        AddEntropy();
        MazeCell randomStart = cavegrid[Random.Range(0, xsize), Random.Range(0, zsize)];
        Vector3 spawnPos = randomStart.transform.position + Vector3.up * 3f;
        Instantiate(playerpfab, spawnPos, Quaternion.identity);
    }
    

    void GenerateGrid()
    {
        cavegrid = new MazeCell[xsize, zsize];

        for (int x = 0; x < xsize; x++)
        {
            for (int z = 0; z < zsize; z++)
            {
                    Vector3 pos = new Vector3(x * cellsize, 0, z * cellsize);
                    MazeCell newCell = Instantiate(Cavecells, pos, Quaternion.identity);
                    newCell.gridX = x;
                    newCell.gridZ = z;
                    newCell.name = $"Cell_{x}_{z}";
                    cavegrid[x, z] = newCell;
            }
        }
    }

    void GenerateMaze(MazeCell previous, MazeCell current)
    {
        current.Visit();
        finalcell=current;
        if (previous != null)
        ClearWallsBetween(previous, current);

        MazeCell next;
        do
        {
            next = GetRandomUnvisitedNeighbor(current);
            if (next != null)
            {
                GenerateMaze(current, next);
            }
            }while(next != null);
        }

    MazeCell GetRandomUnvisitedNeighbor(MazeCell cell)
    {
        var unvisited = GetUnvisitedNeighbors(cell);
        if (unvisited.Count == 0) return null;
        return unvisited[Random.Range(0, unvisited.Count)];
    }

    List<MazeCell> GetUnvisitedNeighbors(MazeCell cell)
    { 
        List<MazeCell> neighbors = new List<MazeCell>();
        int x = cell.gridX;
        int z = cell.gridZ;

        if (x > 0 && !cavegrid[x - 1, z].Visited)
        {
            neighbors.Add(cavegrid[x - 1, z]);
        }
        if (x < xsize - 1 && !cavegrid[x + 1, z].Visited)
        { 
            neighbors.Add(cavegrid[x + 1, z]);
        }
        if (z > 0 && !cavegrid[x, z - 1].Visited)
        {
            neighbors.Add(cavegrid[x, z - 1]);
        }
        if (z < zsize - 1 && !cavegrid[x, z + 1].Visited)
        {
            neighbors.Add(cavegrid[x, z + 1]);
        }

            return neighbors;
        }

        void ClearWallsBetween(MazeCell beforecell, MazeCell currentcell)
        {
            int dx = currentcell.gridX - beforecell.gridX;
            int dz = currentcell.gridZ - beforecell.gridZ;
            
            if (dx == 1)//current to the right
            {
                beforecell.ClearRight();
                currentcell.ClearLeft();
            }
            else if (dx == -1) //current to the left
            {
                beforecell.ClearLeft();
                currentcell.ClearRight();
            }
            else if (dz == 1) //current above
            {
                currentcell.ClearNorth();
                beforecell.ClearSouth();
            }
            else if (dz == -1) //current bellow
            {
                currentcell.ClearSouth();
                beforecell.ClearNorth();
            }
        }

    void AddEntropy()
    {
        List<MazeCell> eligibleCells = new List<MazeCell>();

        for (int x = 0; x < xsize; x++)
        {
            for (int z = 0; z < zsize; z++)
            {
                MazeCell cell = cavegrid[x, z];
                if (!cell.HasEntropy && !cell.HasEndwall && cell.Visited)
                {
                    eligibleCells.Add(cell);
                }
            }
        }

        int count = Mathf.Min(EntropyNum, eligibleCells.Count);
        int[] usedIndexes = new int[EntropyNum];
        int added = 0;

        while (added < EntropyNum)
        {
            int index = Random.Range(0, eligibleCells.Count);
            bool alreadyUsed = false;

            for (int i = 0; i < added; i++)
            {
                if (usedIndexes[i] == index)
                {
                    alreadyUsed = true;
                    break;
                }
            }
            if (alreadyUsed == false)
            {
                usedIndexes[added] = index;
                eligibleCells[index].GainEntropy();
                added++;
            }
        }

    }
}


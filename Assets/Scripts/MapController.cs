using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject prefab;
    public int sizeMap;
    int[,] grid;
    System.Random rdn = new System.Random();
    void Start()
    {
        grid =new int[sizeMap, sizeMap];
        GenerateMap();
    }

    void Update()
    {
        
    }
    void GenerateMap()
    {
        Stack<Vector2Int> current = new Stack<Vector2Int>();
        Vector2Int start = new Vector2Int(1, 1);
      
        grid[start.x, start.y] = 1;
        current.Push(start);
        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(0, 2), new Vector2Int(0, -2)
            ,new Vector2Int(2, 0), new Vector2Int(-2, 0)
        };

        //Planear

        bool isDone = false;
        while (current.Count>0)
        {
            Vector2Int tmp = current.Peek();
            CalculateRdnDirection(directions);
            isDone = false;
          
            foreach (Vector2Int dir in directions)
            {
            
                int newX = tmp.x + dir.x;
                int newY = tmp.y + dir.y;

                if (IsInMap(newX, newY) && grid[newX, newY] == 0)
                {
                    grid[newX, newY] = 1;
                    grid[tmp.x + (dir.x / 2), tmp.y + (dir.y / 2)] = 1;
                    //current.Pop();
                    current.Push(new Vector2Int(newX, newY));
                    isDone = true;
                    break;
                } 

            }
            if (!isDone)
            {
                current.Pop();
            }        
        }
    

        //Dibuja el laberinto
        for (int x = 0; x < sizeMap; x++)
        {
            for(int y = 0; y <sizeMap; y++)
            {
                if(grid[x, y] == 0)
                {
                    Instantiate(prefab, new Vector3(x,y,0), Quaternion.identity);
                }
            }
        }
    }
    //y=alto y x=ancho
    bool IsInMap(int x, int y)
    {
        return x > 0 && y > 0 && x < sizeMap-1 && y < sizeMap-1;
    }
    void CalculateRdnDirection(List<Vector2Int> directions)
    {
        for (int i = 0; i < directions.Count - 1; i++)
        {
            int k = rdn.Next(directions.Count);
            Vector2Int tmp = directions[k];       
            directions[k] = directions[i];
            directions[i] = tmp;
        }
    }
}

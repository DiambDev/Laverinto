using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    //public GameObject pInit1, pInit2;
    public GameObject p1, p2;
    public int width = 21, height = 21;
    public Wall wallPrefab;
    public float extraPathChance = 0.2f; 

    private int[,] grid;
    private System.Random rand = new System.Random();
    private WallPool wallPool;

    void Start()
    {
        grid = new int[width, height];
        wallPool = new WallPool(wallPrefab, width * height);
        p1.transform.position = new Vector3(1.5f, 1.5f, 0);
        GenerateMaze();
        AddExtraPaths();
        DrawMaze();
    }

    void GenerateMaze()
    {
        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        Vector2Int start = new Vector2Int(1, 1);
        stack.Push(start);
        grid[start.x, start.y] = 1;

        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(0, 2), new Vector2Int(2, 0),
            new Vector2Int(0, -2), new Vector2Int(-2, 0)
        };

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();
            directions.Shuffle();
            bool moved = false;

            foreach (Vector2Int dir in directions)
            {
                int nx = current.x + dir.x, ny = current.y + dir.y;

                if (IsInBounds(nx, ny) && grid[nx, ny] == 0)
                {
                    grid[nx, ny] = 1;
                    grid[current.x + dir.x / 2, current.y + dir.y / 2] = 1; // Eliminar muro
                    stack.Push(new Vector2Int(nx, ny));
                    moved = true;
                    break;
                }
            }

            if (!moved)
            {
                stack.Pop();
            }
        }
    }

    void AddExtraPaths()
    {
        for (int x = 1; x < width - 1; x += 2)
        {
            for (int y = 1; y < height - 1; y += 2)
            {
                if (rand.NextDouble() < extraPathChance)
                {
                    List<Vector2Int> directions = new List<Vector2Int>
                    {
                        new Vector2Int(0, 1), new Vector2Int(1, 0),
                        new Vector2Int(0, -1), new Vector2Int(-1, 0)
                    };
                    directions.Shuffle();

                    foreach (var dir in directions)
                    {
                        int nx = x + dir.x, ny = y + dir.y;
                        if (IsInBounds(nx, ny) && grid[nx, ny] == 0)
                        {
                            grid[nx, ny] = 1; 
                            break;
                        }
                    }
                }
            }
        }
    }

    void DrawMaze()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y] == 0)
                {
                    wallPool.GetWall(new Vector3(x,y, 0));
                }
            }
        }
    }

    bool IsInBounds(int x, int y)
    {
        return x > 0 && y > 0 && x < width - 1 && y < height - 1;
    }
}


public class WallPool
{
    private Queue<Wall> pool = new Queue<Wall>();
    private Wall prefab;

    public WallPool(Wall prefab, int initialSize)
    {
        this.prefab = prefab;
        for (int i = 0; i < initialSize; i++)
        {
            Wall wall = GameObject.Instantiate(prefab);
            wall.gameObject.SetActive(false);
            pool.Enqueue(wall);
        }
    }

    public Wall GetWall(Vector3 position)
    {
        Wall wall;
        if (pool.Count > 0)
        {
            wall = pool.Dequeue();
            wall.transform.position = position;
            wall.gameObject.SetActive(true);
        }
        else
        {
            wall = GameObject.Instantiate(prefab, position, Quaternion.identity);
        }
        return wall;
    }

    public void ReturnWall(Wall wall)
    {
        wall.gameObject.SetActive(false);
        pool.Enqueue(wall);
    }
}


public static class Extensions
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}

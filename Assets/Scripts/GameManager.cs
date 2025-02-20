using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    readonly int width = 10;
    readonly int height = 10;
    readonly int bombs = 10;
    readonly int bomb = -1; // Guardará si tiene bomba (-1) o el número de bombas alrededor (entre 0 y 8)
    int[,] grid;

    GameObject unrevealed;
    enum CellNames { Unrevealed, Revealed, Flagged }
    readonly string _prefabsPath = "Prefabs/Cells/";

    Dictionary<string, GameObject> cellPrefabs = new Dictionary<string, GameObject>{

    };

    void Awake()
    {
        unrevealed = Resources.Load<GameObject>($"{_prefabsPath}unrevealed");
        InitializeGrid();
        ShowGrid();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void ShowGrid()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector2Int position = new Vector2Int(x, y);
                Instantiate(unrevealed, new Vector3(position.x, position.y, 0), Quaternion.identity);
                Debug.Log($"{x}-{y}: {grid[x, y]}");
            }
        }
    }

    void InitializeGrid()
    {
        grid = new int[width, height];
        int bombsPlaced = 0;
        while (bombsPlaced < bombs)
        {
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            if (grid[x, y] != bomb)
            {
                grid[x, y] = bomb;
                bombsPlaced++;
            }
        }
    }
}

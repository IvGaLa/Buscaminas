using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static int _width, _height, _bombs, _camSize;
    static readonly int _bomb = -1; // Guardará si tiene bomba (-1) o el número de bombas alrededor (entre 0 y 8)
    static int[,] _grid;
    static float _offsetX, _offsetY;
    static int _totalRevealed, _cellsRevealed;

    void Awake()
    {
        GetGameSettings();
        InitializeGrid();
        SetCamSize();
        ShowGrid();
    }


    void SetCamSize()
    {
        Camera.main.orthographicSize = _camSize;
    }

    void ShowGrid()
    {
        // Cargamos el prefab de la celda por defecto (unrevealed)
        GameObject _cellPrefab = Resources.Load<GameObject>(ConfigVariables.GetConfigValue<string>(configTypes.PREFABS_CELLS_PATH) + ConfigVariables.GetConfigValue<string>(configTypes.PREFAB_CELL));

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                Vector3 position = new(x + _offsetX, y + _offsetY, 0);
                GameObject cell = Instantiate(_cellPrefab, position, Quaternion.identity);
                Cell cellScript = cell.GetComponent<Cell>();

                CellData cellData = new CellData();
                cellData.Position = position;
                cellData.HasBomb = _grid[x, y] == _bomb;
                cellData.GridPositionX = x;
                cellData.GridPositionY = y;
                cellScript.InitializeCellData(cellData);
                cell.name = $"{x}-{y}";
            }
        }
    }

    void InitializeGrid()
    {
        // Añadimos un "offset" para centrar las casillas
        _offsetX = -_width / 2.0f;
        _offsetY = -_height / 2.0f;

        _grid = new int[_width, _height];
        int bombsPlaced = 0;
        while (bombsPlaced < _bombs)
        {
            int x = Random.Range(0, _width);
            int y = Random.Range(0, _height);
            if (_grid[x, y] != _bomb)
            {
                _grid[x, y] = _bomb;
                bombsPlaced++;
            }
        }
    }

    void GetGameSettings(difficultyTypes difficulty = difficultyTypes.EASY)
    {
        (_width, _height, _bombs, _camSize) = GameSettings.GetGameSettings()[difficulty];
        _totalRevealed = _width * _height - _bombs;
        _cellsRevealed = 0;
    }

    static public bool CheckHasBomb(int x, int y)
    {
        return CheckInBounds(x, y) && _grid[x, y] == _bomb;
    }

    static bool CheckInBounds(int x, int y)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }

    public static void AddCellRevealed()
    {
        _cellsRevealed++;
        CheckWin();
    }


    static void CheckWin()
    {
        if (_cellsRevealed == _totalRevealed)
        {
            SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.WIN]);
        }
    }

    public static void GameOver()
    {
        SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.LOSE]);
    }
}

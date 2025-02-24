using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int _width, _height, _bombs, _camSize;
    readonly int BOMB = -1; // Guardará si tiene bomba (-1)
    int[,] _grid;
    int _totalRevealed, _cellsRevealed;
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantenemos el objeto en todas las escenas
        }
        else
        {
            Destroy(gameObject); // Destruimos el objeto si ya existe
        }
        GetGameSettings();
        InitializeGrid();
        SetCamSize();
        ShowGrid();
    }


    void SetCamSize()
    {
        // Ajustamos el tamaño de la cámara en función del tamaño de la cuadrícula
        Camera.main.orthographicSize = _camSize;

        // Centramos la cámara en relación al tamaño de la cuadrícula
        Camera.main.transform.position = new Vector3(_width / 2f, _height / 2f, -10);
    }

    void ShowGrid()
    {
        // Cargamos el prefab de la celda por defecto (unrevealed)
        GameObject _cellPrefab = Resources.Load<GameObject>(ConfigVariables.GetConfigValue<string>(configTypes.PREFABS_CELLS_PATH) + ConfigVariables.GetConfigValue<string>(configTypes.PREFAB_CELL));

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                Vector3 position = new(x, y, 0);
                GameObject cell = Instantiate(_cellPrefab, position, Quaternion.identity);
                Cell cellScript = cell.GetComponent<Cell>();

                CellData cellData = new()
                {
                    HasBomb = _grid[x, y] == BOMB,
                    HasFlag = false,
                    Position = new Vector2Int(x, y),
                };

                cellScript.InitializeCellData(cellData);
                cell.name = $"{x}-{y}";
            }
        }
    }

    void InitializeGrid()
    {
        _grid = new int[_width, _height];
        int bombsPlaced = 0;
        while (bombsPlaced < _bombs)
        {
            int x = Random.Range(0, _width);
            int y = Random.Range(0, _height);
            if (_grid[x, y] != BOMB)
            {
                _grid[x, y] = BOMB;
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

    public bool CheckHasBomb(int x, int y)
    {
        return CheckInBounds(x, y) && _grid[x, y] == BOMB;
    }

    bool CheckInBounds(int x, int y)
    {
        return x >= 0 && x < _width && y >= 0 && y < _height;
    }

    public void AddCellRevealed()
    {
        _cellsRevealed++;
        CheckWin();
    }


    void CheckWin()
    {
        if (_cellsRevealed == _totalRevealed)
        {
            Debug.Log("You win");
            //SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.WIN]);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        //SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.LOSE]);
    }
}

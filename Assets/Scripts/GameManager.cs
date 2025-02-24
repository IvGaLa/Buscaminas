using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    readonly int DELAY_WIN = 5;
    readonly int DELAY_LOSE = 10;
    readonly int BOMB = -1; // Guardará si tiene bomba (-1)
    int _width, _height, _bombs, _camSize;
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
        StartCoroutine(ResetGame());
    }

    IEnumerator ResetGame(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        DestroyAllCells();
        GetGameSettings();
        InitializeGrid();
        SetCamSize();
        ShowGrid();
    }

    void DestroyAllCells()
    {
        GameObject[] cells = GameObject.FindGameObjectsWithTag(Tags.GetTagName()[tagsTypes.CELL]);
        foreach (var cell in cells)
            Destroy(cell);
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
                cell.tag = Tags.GetTagName()[tagsTypes.CELL];
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
        (_width, _height, _bombs) = GameSettings.GetGameSettings()[difficulty];
        _camSize = (Mathf.Max(_width, _height) / 2) + 1;
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
            StartCoroutine(ResetGame(DELAY_WIN));
            //SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.WIN]);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        StartCoroutine(ResetGame(DELAY_LOSE));
        //SceneManager.LoadScene(ScenesVariables.GetScenesVariables()[scenesTypes.LOSE]);
    }

    public void RevealCell(Cell cell)
    {
        cell.CellData.IsRevealed = true;
        AddCellRevealed();
        int x = cell.CellData.Position.x;
        int y = cell.CellData.Position.y;
        int countBombs = cell.CountBombs(x, y);

        cell.ChangeSprite((spritesNamesTypes)countBombs);

        if (countBombs > 0)
            return;

        foreach (var direction in Directions.GetDirections())
        {
            int dx = direction.Value.x;
            int dy = direction.Value.y;
            int nx = x + dx;
            int ny = y + dy;
            if (!CheckHasBomb(nx, ny))
            {
                GameObject newCell = GameObject.Find($"{nx}-{ny}");
                Cell newCellScript = newCell.GetComponent<Cell>();
                RevealCell(newCellScript);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    readonly int DELAY_WIN = 5;
    readonly int DELAY_LOSE = 10;
    readonly int BOMB = -1; // Guardará si tiene bomba (-1)
    readonly Stack<string> _bombsCoords = new(); // Guarda las coordenadas de las bombas en el grid

    int _width, _height, _bombs, _camSize, _totalRevealed, _cellsRevealed;
    int[,] _grid;
    bool _playing;

    public static GameManager Instance { get; private set; }
    public bool Playing => _playing;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject); // Mantenemos el objeto en todas las escenas
        }
        else
        {
            Destroy(gameObject); // Destruimos el objeto si ya existe
        }
    }

    void OnDestroy() => SceneManager.sceneLoaded -= OnSceneLoaded;

    // Inicializamos el juego
    void StartGame(float delay = 0) => StartCoroutine(ResetGame(delay));

    IEnumerator ResetGame(float delay = 0)
    {
        _playing = false;
        yield return new WaitForSeconds(delay);
        DestroyAllCells();
        GetGameSettings(ConfigVariables.GetConfigValue<GameSettingsTypes>(ConfigTypes.DIFFICULTY));
        InitializeGrid();
        SetCamSize();
        ShowGrid();
        _playing = true;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == ScenesVariables.GetScenesVariables(ScenesTypes.GAME))
            StartGame();
    }

    void DestroyAllCells()
    {
        GameObject[] allCells = GameObject.FindGameObjectsWithTag(Tags.GetTagName(TagsTypes.CELL));
        foreach (var cell in allCells)
            Destroy(cell);
    }

    void GetGameSettings(GameSettingsTypes difficulty = GameSettingsTypes.EASY)
    {
        _width = GameSettings.GetGameSettings(difficulty).Width;
        _height = GameSettings.GetGameSettings(difficulty).Height;
        _bombs = GameSettings.GetGameSettings(difficulty).Bombs;
        _camSize = (Mathf.Max(_width, _height) / 2) + 1;
        _totalRevealed = _width * _height - _bombs;
        _cellsRevealed = 0;
    }

    void InitializeGrid()
    {
        _grid = new int[_width, _height];
        _bombsCoords.Clear();
        FillRandomBombs();
    }

    void FillRandomBombs()
    {
        while (_bombsCoords.LongCount() < _bombs)
        {
            int x = Random.Range(0, _width);
            int y = Random.Range(0, _height);
            if (_grid[x, y] != BOMB)
            {
                _grid[x, y] = BOMB;
                _bombsCoords.Push($"{x}-{y}");
            }
        }
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
        GameObject _cellPrefab = Resources.Load<GameObject>(ConfigVariables.GetConfigValue<string>(ConfigTypes.PREFABS_CELLS_PATH) + ConfigVariables.GetConfigValue<string>(ConfigTypes.PREFAB_CELL));

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

    public bool CheckHasBomb(int x, int y) => CheckInBounds(x, y) && _grid[x, y] == BOMB;

    bool CheckInBounds(int x, int y) => x >= 0 && x < _width && y >= 0 && y < _height;

    public void AddCellRevealed()
    {
        _cellsRevealed++;
        CheckWin();
    }


    void CheckWin()
    {
        if (_cellsRevealed == _totalRevealed)
            WinGame();
    }


    void WinGame()
    {
        ScreenShot.TakeScreenShot();
        StartGame(DELAY_WIN);
    }

    public void GameOver(Cell cell)
    {
        RevealGrid(cell);
        StartGame(DELAY_LOSE);
    }

    void RevealGrid(Cell cell)
    {
        foreach (string bomb in _bombsCoords)
        {
            if (cell.name != bomb)
            {
                Cell cellScript = GameObject.Find(bomb).GetComponent<Cell>();
                if (cellScript.CellData.HasBomb)
                    cellScript.ChangeSprite(SpritesNamesTypes.BOMB_1);
            }
        }
    }

    public void RevealCell(Cell cell)
    {
        Stack<Cell> cellsToReveal = new Stack<Cell>();
        cellsToReveal.Push(cell);

        while (cellsToReveal.Count > 0)
        {
            Cell currentCell = cellsToReveal.Pop();
            if (!currentCell.CellData.IsRevealed)
            {
                currentCell.CellData.IsRevealed = true;
                AddCellRevealed();
            }
            int x = currentCell.CellData.Position.x;
            int y = currentCell.CellData.Position.y;
            int countBombs = currentCell.CountBombs(x, y);

            currentCell.ChangeSprite((SpritesNamesTypes)countBombs);

            if (countBombs > 0)
                continue;

            foreach (var direction in Directions.GetDirections())
            {
                int dx = direction.Value.x;
                int dy = direction.Value.y;
                int nx = x + dx;
                int ny = y + dy;
                if (!CheckHasBomb(nx, ny))
                {
                    GameObject newCell = GameObject.Find($"{nx}-{ny}");
                    if (newCell != null)
                    {
                        Cell newCellScript = newCell.GetComponent<Cell>();
                        if (!newCellScript.CellData.IsRevealed)
                            cellsToReveal.Push(newCellScript);

                    }
                }
            }
        }
    }
}

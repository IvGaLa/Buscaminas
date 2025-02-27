using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    readonly int DELAY_WIN = 5;
    readonly int DELAY_LOSE = 10;
    readonly int BOMB = -1; // Guardará si tiene bomba (-1)

    int _width, _height, _bombs, _camSize, _totalRevealed, _cellsRevealed;
    int[,] _grid;
    bool _playing;

    public static GameManager Instance { get; private set; }
    public bool Playing => _playing;
    GameObject cells; // GameObject padre de todas las celdas.
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

        // Inicializamos el juego
        StartCoroutine(ResetGame());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PrintGrid();
    }

    // Used for debugging
    void PrintGrid()
    {
        for (int y = 0; y < _height; y++)
        {
            string row = $"{y}:  ";
            for (int x = 0; x < _width; x++)
                row += _grid[x, y] + " ";
            Debug.Log(row);
        }
    }



    IEnumerator ResetGame(float delay = 0)
    {
        _playing = false;
        yield return new WaitForSeconds(delay);
        DestroyAllCells();
        GetGameSettings();
        InitializeGrid();
        SetCamSize();
        ShowGrid();
        _playing = true;
    }

    void DestroyAllCells()
    {
        GameObject[] allCells = GameObject.FindGameObjectsWithTag(Tags.GetTagName()[tagsTypes.CELL]);
        foreach (var cell in allCells)
            Destroy(cell);
    }

    void GetGameSettings(difficultyTypes difficulty = difficultyTypes.EASY)
    {
        (_width, _height, _bombs) = GameSettings.GetGameSettings()[difficulty];
        _camSize = (Mathf.Max(_width, _height) / 2) + 1;
        _totalRevealed = _width * _height - _bombs;
        _cellsRevealed = 0;
    }

    void InitializeGrid()
    {
        GetCellsParent();
        _grid = new int[_width, _height];
        FillRandomBombs();
    }
    void GetCellsParent() => cells = GameObject.Find("Cells");

    void FillRandomBombs()
    {
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
                cell.transform.SetParent(cells.transform);
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

            currentCell.ChangeSprite((spritesNamesTypes)countBombs);

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

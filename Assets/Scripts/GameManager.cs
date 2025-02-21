using UnityEngine;

public class GameManager : MonoBehaviour
{
    int _width, _height, _bombs, _camSize;
    int _bomb = -1; // Guardará si tiene bomba (-1) o el número de bombas alrededor (entre 0 y 8)
    int[,] _grid;

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
        // Añadimos un "offset" para centrar las casillas
        float offsetX = -_width / 2.0f;
        float offsetY = -_height / 2.0f;

        // Cargamos la celda por defecto (unrevealed)
        string _prefabsPath = ConfigVariables.GetConfigVariables()[configTypes.PREFABS_CELLS_PATH];
        string _unrevealedCell = ConfigVariables.GetConfigVariables()[configTypes.UNREVEALED_CELL];
        GameObject _unrevealed = Resources.Load<GameObject>($"{_prefabsPath}{_unrevealedCell}");

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                Vector3 position = new(x + offsetX, y + offsetY, 0);
                GameObject cell = Instantiate(_unrevealed, position, Quaternion.identity);
                Cell cellScript = cell.GetComponent<Cell>();
                cellScript.Position = position;
                cellScript.HasBomb = _grid[x, y] == _bomb;
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
    }
}

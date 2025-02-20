using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    int _width, _height, _bombs, _camSize;
    int _bomb = -1; // Guardará si tiene bomba (-1) o el número de bombas alrededor (entre 0 y 8)
    int[,] _grid;
    GameObject _unrevealed;

    void Awake()
    {
        _unrevealed = PrefabsCells.GetPrefabsCells()[prefabsCellsNamesTypes.UNREVEALED];
        GetDifficulty();
        InitializeGrid();
        SetCamSize();
        ShowGrid();
    }

    void SetCamSize()
    {
        Debug.Log(Camera.main.orthographicSize);
        Debug.Log(_camSize);
        Camera.main.orthographicSize = _camSize;
        Debug.Log(Camera.main.orthographicSize);
    }

    void ShowGrid()
    {

        float offsetX = -_width / 2.0f + 0.5f;
        float offsetY = -_height / 2.0f + 0.5f;

        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                Vector3 position = new Vector3(x + offsetX, y + offsetY, 0);
                Instantiate(_unrevealed, new Vector3(position.x, position.y, 0), Quaternion.identity);
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

    void GetDifficulty()
    {
        Dictionary<difficultyTypes, (int width, int height, int bombs, int camSize)> gameSettings = GameSettings.GetGameSettings();
        difficultyTypes randomDifficulty = (difficultyTypes)Random.Range(0, gameSettings.Count);
        (_width, _height, _bombs, _camSize) = gameSettings[randomDifficulty];
    }
}

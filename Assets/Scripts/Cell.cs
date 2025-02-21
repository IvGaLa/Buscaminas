using UnityEngine;

public class Cell : MonoBehaviour
{

    Vector3 _position; // Posición en el grid
    bool _hasBomb;        // Si es una bomba
    int _adjacentBombs;   // Bombas cercanas
    bool _isRevealed;     // Si la celda fue revelada

    // Setters/Getters
    public Vector3 Position { get => _position; set => _position = value; }
    public bool HasBomb { get => _hasBomb; set => _hasBomb = value; }
    public int AdjacentBombs { get => _adjacentBombs; set => _adjacentBombs = value; }
    public bool IsRevealed { get => _isRevealed; set => _isRevealed = value; }

    // // Método para inicializar la celda con sus propiedades
    // public void Initialize(Vector2Int pos, bool bomb)
    // {
    //     position = pos;
    //     hasBomb = bomb;
    //     adjacentBombs = 0; // Se calculará luego
    //     isRevealed = false;
    // }

    // // Método para asignar el número de bombas cercanas
    // public void SetAdjacentBombs(int count)
    // {
    //     adjacentBombs = count;
    // }

    // Método para revelar la celda
    void Reveal()
    {
        _isRevealed = true;
        // TO-DO: Comprobar que no es una bomba. Si lo es, mostrar
        // la animación de explosión y terminar el juego.
        // TO-DO: Si no es una bomba, mostrar el número de bombas
        // cercanas o dejar la celda vacía.
        if (_hasBomb)
        {
            Debug.Log("¡¡¡BOOM!!!");
        }
        else
        {
            Debug.Log("¡¡¡NO BOOM!!!");
        }
    }

    void OnMouseDown()
    {
        if (!_isRevealed)
        {
            Reveal();
        }
    }
}

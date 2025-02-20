using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int position { get; private set; } // Posición en el grid
    public bool hasBomb { get; private set; }        // Si es una bomba
    public int adjacentBombs { get; private set; }   // Bombas cercanas
    public bool isRevealed { get; private set; }     // Si la celda fue revelada

    // Método para inicializar la celda con sus propiedades
    public void Initialize(Vector2Int pos, bool bomb)
    {
        position = pos;
        hasBomb = bomb;
        adjacentBombs = 0; // Se calculará luego
        isRevealed = false;
    }

    // Método para asignar el número de bombas cercanas
    public void SetAdjacentBombs(int count)
    {
        adjacentBombs = count;
    }

    // Método para revelar la celda
    public void Reveal()
    {
        isRevealed = true;
        // TO-DO: Cambiar sprite
    }
}

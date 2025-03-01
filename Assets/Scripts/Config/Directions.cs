using System.Collections.Generic;
public class Directions
{
  static readonly Dictionary<int, (int x, int y)> _directions = new(){
    // Definimos las posiciones adyacentes de la celda a comprobar
    {0, (x: 0, y: 1)},  // La celda 0 es la celda de arriba
    {1, (x: 1, y: 1)},  // La celda 1 es la celda de arriba a la derecha
    {2, (x: 1, y: 0)},  // La celda 2 es la celda de la derecha
    {3, (x: 1, y: -1)}, // La celda 3 es la celda de abajo a la derecha
    {4, (x: 0, y: -1)}, // La celda 4 es la celda de abajo
    {5, (x: -1, y: -1)},// La celda 5 es la celda de abajo a la izquierda
    {6, (x: -1, y: 0)}, // La celda 6 es la celda de la izquierda
    {7, (x: -1, y: 1)}, // La celda 7 es la celda de arriba a la izquierda 
  };

  public static Dictionary<int, (int x, int y)> GetDirections() => _directions;
}
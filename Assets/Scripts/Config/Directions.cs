using System.Collections.Generic;

public static class Directions
{
  public static Dictionary<int, (int x, int y)> GetDirections()
  {
    Dictionary<int, (int x, int y)> _directions = new() {
      // Definimos las posiciones adyacentes de la celda a comprobar
      // La celda 0 es la celda de arriba
      // La celda 1 es la celda de arriba a la derecha
      // La celda 2 es la celda de la derecha
      // La celda 3 es la celda de abajo a la derecha
      // La celda 4 es la celda de abajo
      // La celda 5 es la celda de abajo a la izquierda
      // La celda 6 es la celda de la izquierda
      // La celda 7 es la celda de arriba a la izquierda
      {0, (x: 0, y: 1)},
      {1, (x: 1, y: 1)},
      {2, (x: 1, y: 0)},
      {3, (x: 1, y: -1)},
      {4, (x: 0, y: -1)},
      {5, (x: -1, y: -1)},
      {6, (x: -1, y: 0)},
      {7, (x: -1, y: 1)},
    };
    return _directions;
  }


}
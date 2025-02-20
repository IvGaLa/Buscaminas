using System;
using System.Collections.Generic;
using UnityEngine;

public static class PrefabsCells
{
  readonly static string _prefabsPath = ConfigVariables.GetConfigVariables()[configTypes.PREFABS_CELLS_PATH];

  public static Dictionary<prefabsCellsNamesTypes, GameObject> GetPrefabsCells()
  {
    Dictionary<prefabsCellsNamesTypes, GameObject> _prefabsCells = new();
    foreach (prefabsCellsNamesTypes cell in Enum.GetValues(typeof(prefabsCellsNamesTypes)))
      _prefabsCells.Add(cell, Resources.Load<GameObject>($"{_prefabsPath}{PrefabsCellsNamesVariables.GetPrefabsNames()[cell]}"));

    return _prefabsCells;
  }
}
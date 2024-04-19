using System.Collections;
using System.Collections.Generic;
using TileGeneration;
using UnityEngine;

[CreateAssetMenu]
public class GeneralVariables : ScriptableObject
{
    public int rows, cols,spacing,tileThatCanSpawn;
    public Sprite[] allTilesImages;
    public GameObject tile;
    public GameObject horizontalTable, verticleTable;
}

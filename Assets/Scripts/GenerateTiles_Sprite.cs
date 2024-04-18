using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles_Sprite : MonoBehaviour
{
    public GameObject tilePrefab; // Assign your tile prefab in the inspector
    public int rows = 5;
    public int columns = 5;
    public float spacing = 10f;

    public void Generate(JsonData data)
    {
        Vector2 startPosition = new Vector2(0, 0);
        int tileCounter = 0;
        float tileSizeX = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileSizeY = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        // Create tiles in a grid layout
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                tileCounter++;
                // Instantiate tile prefab
                GameObject tile = Instantiate(tilePrefab, transform);
                // Set tile position
                Vector2 tilePosition = new Vector2(startPosition.x + col * (tileSizeX + spacing), startPosition.y - row * (tileSizeY + spacing));
                tile.transform.position = tilePosition;

                // Set tile properties
                TileProperty property = data.TerrainGrid[row][col];
                tile.GetComponent<Tile>().tileId = property.TileType;
                tile.GetComponent<Tile>().index = tileCounter;
                tile.name = tileCounter.ToString();

                tile.SetActive(true);
            }
        }
    }
}
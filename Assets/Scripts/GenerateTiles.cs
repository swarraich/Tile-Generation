using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles : MonoBehaviour
{
    public GameObject tilePrefab; // Assign your tile prefab in the inspector
    public int rows = 5;
    public int columns = 5;
    public float spacing = 10f; 
    void Start()
    {
        //Generate();
    }

   public void Generate(JsonData data)
    {
        RectTransform parentTransform = GetComponent<RectTransform>();

        // Calculate tile size based on parent's size and desired spacing
        float tileSizeX = (parentTransform.rect.width - (spacing * (columns - 1))) / columns;
        float tileSizeY = (parentTransform.rect.height - (spacing * (rows - 1))) / rows;

        Vector2 startPosition = new Vector2(0, 0);
        int tileCounter=0;
        // Create tiles in a grid layout
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                tileCounter++;
                // Instantiate tile prefab
                GameObject tile = Instantiate(tilePrefab, transform);
                tile.transform.parent = parentTransform;
                // Set tile position and size
                RectTransform tileTransform = tile.GetComponent<RectTransform>();
                TileProperty property = data.TerrainGrid[row][col];
                tile.GetComponent<Tile>().tileId = property.TileType;
                tile.GetComponent<Tile>().index = tileCounter;
                tile.name = tileCounter.ToString();
                tileTransform.sizeDelta = new Vector2(tileSizeX, tileSizeY);
                tileTransform.anchoredPosition = new Vector2(startPosition.x + col * (tileSizeX + spacing), startPosition.y - row * (tileSizeY + spacing));
                tile.SetActive(true);
            }
        }
    }
}

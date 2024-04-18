using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileGeneration;
public class GenerateTiles_Sprite : MonoBehaviour
{
   
    public GeneralVariables generalVariables;

    public void Generate(JsonData data)
    {
        Vector2 startPosition = new Vector2(0, 0);
        int tileCounter = 0;
        float tileSizeX = generalVariables.tile.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileSizeY = generalVariables.tile.GetComponent<SpriteRenderer>().bounds.size.y;

        // Create tiles in a grid layout
        for (int row = 0; row < generalVariables.rows; row++)
        {
            for (int col = 0; col < generalVariables.cols; col++)
            {
                tileCounter++;
                // Instantiate tile prefab
                GameObject tile = TileFactory.CreateTile(0, transform, generalVariables);//Instantiate(generalVariables.tile, transform);
                // Set tile position
                Vector2 tilePosition = new Vector2(startPosition.x + col * (tileSizeX +generalVariables.spacing), startPosition.y - row * (tileSizeY + generalVariables.spacing));
                tile.transform.position = tilePosition;

                // Set tile properties
                TileProperty property = data.TerrainGrid[row][col];
                tile.GetComponent<Tile>()._TileId = property.TileType;
                tile.GetComponent<Tile>()._Index = tileCounter;
                tile.name = tileCounter.ToString();

                tile.SetActive(true);
            }
        }
    }
}
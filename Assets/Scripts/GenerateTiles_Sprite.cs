using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TileGeneration;
using UnityEngine.UI;
public class GenerateTiles_Sprite : MonoBehaviour
{
   
    public GeneralVariables _GeneralVariables;
    JsonData _GridData;
    [SerializeField]
    Button _Button;

    private void OnEnable()
    {
        _Button.onClick.AddListener(Reset);
    }

    private void OnDisable()
    {
        _Button.onClick.RemoveListener(Reset);
    }
    public void Generate(JsonData data)
    {
        _GridData = data;
        Vector2 startPosition = new Vector2(0, 0);
        int tileCounter = 0;
        float tileSizeX = _GeneralVariables.tile.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileSizeY = _GeneralVariables.tile.GetComponent<SpriteRenderer>().bounds.size.y;

        // Create tiles in a grid layout
        for (int row = 0; row < _GeneralVariables.rows; row++)
        {
            for (int col = 0; col < _GeneralVariables.cols; col++)
            {
                // Instantiate tile prefab
                GameObject tile = TileFactory.CreateTile(0, transform, _GeneralVariables);//Instantiate(generalVariables.tile, transform);
                // Set tile position
                Vector2 tilePosition = new Vector2(startPosition.x + col * (tileSizeX +_GeneralVariables.spacing), startPosition.y - row * (tileSizeY + _GeneralVariables.spacing));
                tile.transform.position = tilePosition;

                // Set tile properties
                TileProperty property = data.TerrainGrid[row][col];
                tile.GetComponent<Tile>()._TileId = property.TileType;
                tile.GetComponent<Tile>()._Index = tileCounter;
                tileCounter++;
                tile.name = tileCounter.ToString();
                tile.SetActive(true);
            }
        }
    }


    private void Reset()
    {
        Transform[] allTiles = transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in allTiles)
        {
            if(t!=transform)
                Destroy(t.gameObject);
        }
        Generate(_GridData);
    }
}
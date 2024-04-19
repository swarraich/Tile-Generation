using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using System;

namespace TileGeneration
{
    public class JsonData
    {
        public TileProperty[][] TerrainGrid { get; set; }
    }

    public class TileProperty
    {
        public int TileType { get; set; }
    }
    public class Json_reader : MonoBehaviour
    {
        public GenerateTiles _TileGenerator;
        public GenerateTiles_Sprite _TileGenerator_Sprite;
        public GeneralVariables _GeneralVariables;
        //[System.Serializable]





        void Start()
        {

            //for error handling
            try
            {
                // Load JSON file from from resources as text asset
                TextAsset jsonFile = Resources.Load<TextAsset>("data");
                string json = jsonFile.text;
                // Deserialize JSON into TerrainGrid object
                JsonData terrainGrid = JsonConvert.DeserializeObject<JsonData>(json);
                if (terrainGrid == null || terrainGrid.TerrainGrid == null)
                {
                    Debug.LogError("Failed to parse JSON data.");
                    return;
                }
                // Access your terrain data
                _GeneralVariables.rows = terrainGrid.TerrainGrid.Length; // Number of rows
                _GeneralVariables.cols = terrainGrid.TerrainGrid[0].Length;
                //for generating tiles in UI canvas
                //  tileGenerator.Generate(terrainGrid);
                //for generating tiles in spriterendrer
                _TileGenerator_Sprite.Generate(terrainGrid);
            }
            catch(Exception e)
            {
                Debug.LogError(e);
            }

        }
    }
}


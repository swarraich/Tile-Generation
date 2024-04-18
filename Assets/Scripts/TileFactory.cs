using UnityEngine;

namespace TileGenerator
{
    public class TileFactory
    {
        public static GameObject CreateTile(int spawwnType, Transform parent, GeneralVariables generalVariables)
        {
            // Depending on the tile type, instantiate the corresponding prefab
            switch (spawwnType)
            {
                case 0:
                    return InstantiateTile(generalVariables.tile, parent);
                case 1:
                    return InstantiateTile(generalVariables.horizontalTable, parent);
                case 2:
                    return InstantiateTile(generalVariables.verticleTable, parent);
                // Add cases for other tile types as needed
                default:
                    Debug.LogWarning("Unknown tile type: " + spawwnType);
                    return null;
            }
        }

        private static GameObject InstantiateTile(GameObject prefab, Transform parent)
        {
            return GameObject.Instantiate(prefab, parent);
        }
    }
}
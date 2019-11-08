using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Vector2 mapSize;

    public void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        for(int x = 0; x < mapSize.x; x++)
        {
            for(int y = 0; y < mapSize.y; y++)
            {
                Vector2 tilePosition = new Vector2(-mapSize.x / 2 + 0.5f + x,-mapSize.y + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab);
                newTile.position = tilePosition;
            }
        }
    }
}

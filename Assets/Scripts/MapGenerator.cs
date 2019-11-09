using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Transform topWallPrefab;
    public Transform rightWallPrefab;
    public Transform leftWallPrefab;
    public Vector2 mapSize;

    public void Start()
    {
        mapSize.x = 17;
        mapSize.y = 7;
        GenerateMap();
    }

    public void GenerateMap()
    {
        for(int x = 0; x < mapSize.x; x++)
        {
            for(int y = 0; y < mapSize.y; y++)
            {
                Vector2 tilePosition = new Vector2(-mapSize.x + 0.5f + x,-mapSize.y/2 + 0.5f + y);
                Transform newTile = Instantiate(tilePrefab);
                newTile.position = tilePosition;

                //adding top wall tiles
                if(y == (mapSize.y-1))
                {
                    Vector2 wallPosition = new Vector2(-mapSize.x/2 + 0.5f + x, -mapSize.y / 2 + 0.5f + y+1);
                    Transform newWallTile = Instantiate(topWallPrefab);
                    newWallTile.position = wallPosition;
                }

                //adding right walls
                if (x == (mapSize.x - 1))
                {
                    if(y == (mapSize.y-1))
                    {
                        //adding extra wall on the top right to match with top wall tiles
                        Vector2 rightTopWallPosition = new Vector2(-mapSize.x / 2 + 0.5f + x + 1, -mapSize.y / 2 + 0.5f + y+1);
                        Transform newRightTopWallTile = Instantiate(rightWallPrefab);
                        newRightTopWallTile.position = rightTopWallPosition;
                    }

                    //normal right wall tiles
                    Vector2 rightWallPosition = new Vector2(-mapSize.x / 2 + 0.5f + x + 1, -mapSize.y / 2 + 0.5f + y);
                    Transform newRightWallTile = Instantiate(rightWallPrefab);
                    newRightWallTile.position = rightWallPosition;
                }

                //adding left walls
                if(x == 0)
                {
                    if (y == (mapSize.y - 1))
                    {
                        //adding extra wall on the top right to match with top wall tiles
                        Vector2 leftTopWallPosition = new Vector2(-mapSize.x / 2 + 0.5f + x - 1, -mapSize.y / 2 + 0.5f + y+1);
                        Transform newLeftTopWallTile = Instantiate(leftWallPrefab);
                        newLeftTopWallTile.position = leftTopWallPosition;
                    }

                    //adding normal left wall tiles
                    Vector2 leftWallPosition = new Vector2(-mapSize.x / 2 + 0.5f + x-1, -mapSize.y / 2 + 0.5f + y);
                    Transform newleftWallTile = Instantiate(leftWallPrefab);
                    newleftWallTile.position = leftWallPosition;
                }
                
            }
        }
    }
}

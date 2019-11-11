using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform tilePrefab;
    public Transform topWallPrefab;
    public Transform rightWallPrefab;
    public Transform leftWallPrefab;
    public Transform bottomWallPrefab;
    public Transform spikePrefab;
    public Transform topRightCornerPrefab;
    public Transform topLeftCornerPrefab;
    public Transform bottomRightPrefab;
    public Transform bottomLeftPrefab;
    //public Transform rightGatePrefab;
    //public Transform leftGatePrefab;
    public Vector2 mapSize;

    public struct Coord
    {
        public int x;
        public int y;

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y; 
        }
    }

    public List<Coord> allTileCoords;
    public Transform[,] tiles; 
    public int sizeOfList = 0;
    public float lifetime = 10.0f; 

    public void Start()
    {
        mapSize.x = 16;
        mapSize.y = 7;
        allTileCoords = new List<Coord>();
        tiles = new Transform[(int)mapSize.x,(int)mapSize.y];
        GenerateMap();
        
    }

    public void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                StartCoroutine(GenerateSpikes());
                lifetime = 10.0f;
            }

        }
    }

    IEnumerator GenerateSpikes()
    {
        float spawnDelay = 1;
        float speed = 4;

        int numSpikes = 30; 
        for(int x = 0; x < numSpikes; x++)
        {
            float rand = Random.Range(0.0f,(float)(sizeOfList));
            Vector2 spikePositon = getCoordinate((int)(allTileCoords[(int)rand].x), (int)(allTileCoords[(int)rand].y));
            Transform tileWarning = tiles[(int)(allTileCoords[(int)rand].x), (int)(allTileCoords[(int)rand].y)];
            SpriteRenderer tileRend = tileWarning.GetComponentInChildren<SpriteRenderer>();
            Color initialColor = tileRend.color;
            Color flashColor = Color.red;
            float spawnTimer = 0;

            while (spawnTimer < spawnDelay)
            {
                tileRend.color = Color.Lerp(initialColor,flashColor,Mathf.PingPong(spawnTimer*speed,1));
                spawnTimer += Time.deltaTime;
                yield return null;
            }
            
            Transform newSpike = Instantiate(spikePrefab);
            newSpike.position = spikePositon;
        }
    }

    public void GenerateMap()
    {
        //adding top right corner
        Vector2 topRightPosition = new Vector2(mapSize.x/2+0.5f, mapSize.y/2+1.5f);
        Transform newTopRightTile = Instantiate(topRightCornerPrefab);
        newTopRightTile.position = topRightPosition;

        //adding top left corner
        Vector2 topLeftPosition = new Vector2(-mapSize.x / 2 - 0.5f, mapSize.y / 2 + 1.5f);
        Transform newTopLeftTile = Instantiate(topLeftCornerPrefab);
        newTopLeftTile.position = topLeftPosition;

        //adding bottom left corner
        Vector2 bottomLeftPosition = new Vector2(-mapSize.x / 2 - 0.5f, -mapSize.y / 2 - 0.5f);
        Transform newBottomLeftTile = Instantiate(bottomLeftPrefab);
        newBottomLeftTile.position = bottomLeftPosition;

        //adding bottom right corner
        Vector2 bottomRightPosition = new Vector2(mapSize.x / 2 + 0.5f, -mapSize.y / 2 - 0.5f);
        Transform newBottomRightTile = Instantiate(bottomRightPrefab);
        newBottomRightTile.position = bottomRightPosition;

        for (int x = 0; x < mapSize.x; x++)
        {
            for(int y = 0; y < mapSize.y; y++)
            {
                allTileCoords.Add(new Coord(x, y));
                sizeOfList++;

                Vector2 tilePosition = getCoordinate(x, y);
                Transform newTile = Instantiate(tilePrefab);
                newTile.position = tilePosition;

                tiles[x, y] = newTile;

                //adding top wall tiles
                if(y == (mapSize.y-1))
                {
                    Vector2 wallPosition = new Vector2(-mapSize.x/2 + 0.5f + x, -mapSize.y / 2 + 0.5f + y+1);
                    Transform newWallTile = Instantiate(topWallPrefab);
                    newWallTile.position = wallPosition;
                    
                }

                //adding bottom wall tiles
                if(y == 0)
                {
                    Vector2 bottomWallPosition = new Vector2(-mapSize.x / 2 + 0.5f + x, -mapSize.y / 2 + 0.5f + y -1);
                    Transform newBottomWallTile = Instantiate(bottomWallPrefab);
                    newBottomWallTile.position = bottomWallPosition;
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

    public Vector2 getCoordinate(int x, int y)
    {
        return new Vector2(-mapSize.x / 2 + 0.5f + x, -mapSize.y / 2 + 0.5f + y);
    }
}

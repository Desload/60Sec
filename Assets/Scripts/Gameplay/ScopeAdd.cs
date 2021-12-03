using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ScopeAdd : MonoBehaviour
{
    public Tilemap tilemap;
    BoundsInt bounds;
    TileBase[] allTiles;
    public void EndGame()
    {
        bounds = tilemap.cellBounds;
        allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile == null)
                {
                    LevelController.Instance.ScoreUp = 100;
                }
            }
        }
        LevelController.Instance.ScoreUp = -27000;
    }
}

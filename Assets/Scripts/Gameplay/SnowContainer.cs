using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SnowContainer : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private Tile[] tiles;

    private void Awake()
    {

    }

    public void SwitchTile(Vector3Int pos)
    {
        Tile tile = map.GetTile<Tile>(pos);

        if (tile == null)
        {
            map.SetTile(pos, tiles[0]);
        }
        if (tile == tiles[2])
        {
            map.SetTile(pos, null);
            map.SetTile(pos, tiles[0]);
            //TOD: Destroy and spawn Snowman
        }
        else
        {
            if (tile == tiles[2])
            {
                map.SetTile(pos, null);
                map.SetTile(pos, tiles[3]);
            }
            else
            {
                map.SetTile(pos, null);
                map.SetTile(pos, tiles[1]);
            }
        }
    }
}
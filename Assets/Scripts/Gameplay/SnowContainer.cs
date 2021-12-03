using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SnowContainer : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private GameObject snowMan;
    [SerializeField] private Tile[] tiles;

    private void Awake()
    {

    }

    public void SwitchTile(Vector3Int pos,Vector3Int pPos)
    {
        Tile tile = map.GetTile<Tile>(pPos);
        if (tile == null)
        {
            map.SetTile(pos, tiles[0]);
        }
        if (tile == tiles[2])
        {
            Instantiate(snowMan, pos, Quaternion.identity);
        }
        else
        {
            if (tile == tiles[0])
            {
                map.SetTile(pos, null);
                map.SetTile(pos, tiles[1]);
            }
            else if (tile == tiles[1])
            {
                map.SetTile(pos, null);
                map.SetTile(pos, tiles[2]);
            }
        }
    }
}

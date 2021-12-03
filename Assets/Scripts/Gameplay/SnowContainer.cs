using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SnowContainer : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private Snowman snowMan;
    [SerializeField] private Tile[] tiles;

    public void SwitchTile(Vector3Int pos, Vector3Int pPos)
    {
        SoundEffect.Instance.AudioPlay();
        Tile tile = map.GetTile<Tile>(pPos);
        if (tile == null)
        {
            map.SetTile(pos, tile);
        }
        if (tile == tiles[2])
        {
            Instantiate(snowMan.gameObject, pos, Quaternion.identity).GetComponent<Snowman>().container = this;
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

    public void SnowSheet(Vector3Int pos)
    {
        Tile tile = map.GetTile<Tile>(pos);
        if (tile == null)
        {
            map.SetTile(pos, tiles[0]);
        }
    }
}

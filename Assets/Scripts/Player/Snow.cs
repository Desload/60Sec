using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Snow : MonoBehaviour
{
    public Tilemap tilemap;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tile = tilemap.WorldToCell(collision.gameObject.transform.position);
        Debug.Log(tilemap.GetTile(tile));
        tilemap.SetTile(tile, null);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UniRx;
using System;

public class Snow : MonoBehaviour
{
    [SerializeField] private SnowContainer snowContainer;
    private Vector3Int shovelPosition;
    public Tilemap tilemap;
    public Animator PlayerAnimator;
    float vSpeed, hSpeed;
    int dir;
    bool isCan = true;

    private int CheckDir(Animator A)
    {
        hSpeed = A.GetFloat("hSpeed");
        vSpeed = A.GetFloat("vSpeed");
        if (hSpeed > 0 || vSpeed > 0)
        {
            if (hSpeed > vSpeed)
            {
                dir = 1;//Право
            }
            else
            {
                dir = 3;//Вверх
            }
        }
        if (hSpeed < 0 || vSpeed < 0)
        {
            if (hSpeed < vSpeed)
            {
                dir = 2;//Лево
            }
            else
            {
                dir = 4;//Низ
            }
        }
        return dir;

    }

    private void Dig(Animator A, Tilemap t)
    {
        TileBase tDir; // Тайл который двигается относительно направления
        TileBase tRand; // Тайл который выбирается случайно
        CheckDir(A);
        switch (dir)
        {
            case 1:
                //tDir = t.GetTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(-1, 0)));
                snowContainer.SwitchTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(2, 0)),shovelPosition + new Vector3Int(1,0,0));
                t.SetTile(t.WorldToCell(shovelPosition + new Vector3(1, 0)), null); //убираем снег

                //rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                //if(rand == new Vector2(1,0)) //tRand снег не должен попасть в tDir
                //{
                //   rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                //}

                //tRand = t.GetTile<Tile>(t.WorldToCell((Vector2Int)shovelPosition + rand));
                break;

            case 2:
                // tDir = t.GetTile<Tile>(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(1, 0)));
                snowContainer.SwitchTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(-2, 0)),shovelPosition + new Vector3Int(-1, 0, 0));
                t.SetTile(t.WorldToCell(shovelPosition + new Vector3(-1, 0)), null); //убираем снег

                //if (rand == new Vector2(-1, 0)) //tRand снег не должен попасть в tDir
                //{
                //    rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                //}
                break;

            case 3:
                //tDir = t.GetTile<Tile>(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(0, -1)));
                snowContainer.SwitchTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(0, 2)), shovelPosition + new Vector3Int(0, 1, 0));
                t.SetTile(t.WorldToCell(shovelPosition + new Vector3(0, 1)), null); //убираем снег

                //if (rand == new Vector2(0, 1)) //tRand снег не должен попасть в tDir
                //{
                //    rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                //}
                break;

            case 4:
                //tDir = t.GetTile<Tile>(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(0, 1)));
                snowContainer.SwitchTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(0, -2)), shovelPosition + new Vector3Int(0, -1, 0));
                t.SetTile(t.WorldToCell(shovelPosition + new Vector3(0, -1)), null); //убираем снег

                //if (rand == new Vector2(0, 1)) //tRand снег не должен попасть в tDir
                //{
                //    rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                //}
                break;

        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isCan)
        {
            isCan = false;
            Observable.Timer(TimeSpan.FromMilliseconds(500)).Subscribe(_=>isCan=true);
            shovelPosition = tilemap.WorldToCell((Vector2)collision.gameObject.transform.position);
            Dig(PlayerAnimator, tilemap);
        }
    }
}

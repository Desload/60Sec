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
        CheckDir(A);
        switch (dir)
        {
            case 1:
                snowContainer.SwitchTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(2, 0)),shovelPosition + new Vector3Int(1,0,0));
                t.SetTile(t.WorldToCell(shovelPosition + new Vector3(1, 0)), null); //убираем снег
                break;

            case 2:
                snowContainer.SwitchTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(-2, 0)),shovelPosition + new Vector3Int(-1, 0, 0));
                t.SetTile(t.WorldToCell(shovelPosition + new Vector3(-1, 0)), null); //убираем снег
                break;

            case 3:
                snowContainer.SwitchTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(0, 2)), shovelPosition + new Vector3Int(0, 1, 0));
                t.SetTile(t.WorldToCell(shovelPosition + new Vector3(0, 1)), null); //убираем снег
                break;

            case 4:
                snowContainer.SwitchTile(t.WorldToCell((Vector2Int)shovelPosition + new Vector2(0, -2)), shovelPosition + new Vector3Int(0, -1, 0));
                t.SetTile(t.WorldToCell(shovelPosition + new Vector3(0, -1)), null); //убираем снег
                break;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isCan)
        {
            isCan = false;
            Observable.Timer(TimeSpan.FromMilliseconds(50)).Subscribe(_=>isCan=true);
            shovelPosition = tilemap.WorldToCell((Vector2)collision.gameObject.transform.position);
            Dig(PlayerAnimator, tilemap);
        }
    }
}

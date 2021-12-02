using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Snow : MonoBehaviour
{
    public Tilemap tilemap;
    public Animator PlayerAnimator;
    float vSpeed, hSpeed;
    int dir;
    Vector2 rand;

    private void Start()
    {
        PlayerAnimator = GetComponent<Animator>();
    }
    private int CheckDir(Animator A)
    {
        hSpeed = A.GetFloat("hSpeed");
        vSpeed = A.GetFloat("vSpeed");
        if (hSpeed > 0 || vSpeed > 0)
        {
            if (hSpeed > vSpeed)
            {
                dir = 3;//ѕраво
            }
            else
            {
                dir = 1;//¬верх
            }
        }
        if (hSpeed < 0 || vSpeed < 0)
        {
            if (hSpeed > vSpeed)
            {
                dir = 4;//Ћево
            }
            else
            {
                dir = 2;//Ќиз
            }
        }
        return dir;

    }

    private void Dig(Animator A,Tilemap t)
    {
        TileBase tDir; // “айл который двигаетс€ относительно направлени€
        TileBase tRand; // “айл который выбираетс€ случайно
        CheckDir(A);
        switch (dir)
        {
            case 1:
                tDir = t.GetTile(t.WorldToCell((Vector2)gameObject.transform.position + new Vector2(1, 0)));
                t.SetTile(t.WorldToCell((Vector2)gameObject.transform.position), null); //убираем снег
                //тут нужно добавить увеличение сло€ дл€ tDir;
                rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                if(rand == new Vector2(1,0)) //tRand снег не должен попасть в tDir
                {
                   rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                }
                tRand = t.GetTile(t.WorldToCell((Vector2)gameObject.transform.position + rand));
                break;
            case 2:
                tDir = t.GetTile(t.WorldToCell((Vector2)gameObject.transform.position + new Vector2(-1, 0)));
                t.SetTile(t.WorldToCell((Vector2)gameObject.transform.position), null); //убираем снег
                //тут нужно добавить увеличение сло€ дл€ tDir;
                if (rand == new Vector2(-1, 0)) //tRand снег не должен попасть в tDir
                {
                    rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                }
                break;
            case 3:
                tDir = t.GetTile(t.WorldToCell((Vector2)gameObject.transform.position + new Vector2(0, 1)));
                t.SetTile(t.WorldToCell((Vector2)gameObject.transform.position), null); //убираем снег
                //тут нужно добавить увеличение сло€ дл€ tDir;
                if (rand == new Vector2(0, 1)) //tRand снег не должен попасть в tDir
                {
                    rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                }
                break;
            case 4:
                tDir = t.GetTile(t.WorldToCell((Vector2)gameObject.transform.position + new Vector2(0, -1)));
                t.SetTile(t.WorldToCell((Vector2)gameObject.transform.position), null); //убираем снег
                //тут нужно добавить увеличение сло€ дл€ tDir;
                if (rand == new Vector2(0, 1)) //tRand снег не должен попасть в tDir
                {
                    rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
                }
                break;
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tile = tilemap.WorldToCell((Vector2)collision.gameObject.transform.position);
        Dig(PlayerAnimator,tilemap);
    }
}

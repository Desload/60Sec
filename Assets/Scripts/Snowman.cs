using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using UniRx;

public class Snowman : MonoBehaviour
{
    int _dir;
    public float _speed;
    public Rigidbody2D _snowman;
    public float time ; //частота смены направления снеговика

    public SnowContainer container;

    private void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(time)).TakeUntilDisable(gameObject).Subscribe(_ => SetDir());
    }

    private void Update()
    {
        container.SnowSheet(new Vector3Int((int)transform.position.x, (int)transform.position.y, (int)transform.position.z));
    }

    void SetDir()
    {
        _dir = Random.Range(0, 4);
        switch (_dir)
        {
            case 0:
                _snowman.AddForce(transform.up * _speed);
                break;
            case 1:
                _snowman.AddForce(transform.up * -_speed);
                break;
            case 2:
                _snowman.AddForce(transform.right * _speed);
                break;
            case 3:
                _snowman.AddForce(transform.right * -_speed);
                break;
        }
    }
}

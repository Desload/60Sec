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
    Vector2 snowVector;
    public Animator Animator;
    public SnowContainer container;

    private void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(time)).TakeUntilDisable(gameObject).Subscribe(_ => SetDir());
        Animator = GetComponent<Animator>();
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
                snowVector = _snowman.GetVector(transform.up);
                break;
            case 1:
                _snowman.AddForce(transform.up * -_speed);
                snowVector = _snowman.GetVector(transform.up);
                break;
            case 2:
                _snowman.AddForce(transform.right * _speed);
                snowVector = _snowman.GetVector(transform.right);
                break;
            case 3:
                _snowman.AddForce(transform.right * -_speed);
                snowVector = _snowman.GetVector(transform.right);
                break;
        }
        Animator.SetFloat("hSpeed", snowVector.x);
        Animator.SetFloat("vSpeed", snowVector.y);
    }
}

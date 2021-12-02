using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    public Animator _animator;
    public Rigidbody2D Player;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 move = PlayerController.Instance.MoveVector;
        _animator.SetFloat("hSpeed", move.x);
        _animator.SetFloat("vSpeed", move.y);
        Player.velocity = move*speed;
    }
}

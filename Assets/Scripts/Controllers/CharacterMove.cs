using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private PlayerAttack attack;
    private CharacterControll _characterControlls;
    public Animator _animator;
    public Rigidbody2D Player;


    private void Awake()
    {
        _characterControlls = new CharacterControll();
    }

    private void OnEnable()
    {
        _characterControlls.Enable();
    }

    private void OnDisable()
    {
        _characterControlls.Disable();
    }
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector2 move = _characterControlls.Movement.Move.ReadValue<Vector2>();
        _animator.SetFloat("hSpeed", move.x);
        _animator.SetFloat("vSpeed", move.y);
        Player.velocity = move*speed;
    }
}

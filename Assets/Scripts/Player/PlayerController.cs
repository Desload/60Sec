using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private CharacterControll _characterControlls;    

    #region Lambdas controll

    public Vector2 MoveVector => _characterControlls.Movement.Move.ReadValue<Vector2>();
    public Vector2 MousePosition => _characterControlls.Movement.MousePosition.ReadValue<Vector2>();
    

    #endregion


    private void Awake()
    {
        Instance = this;

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
}

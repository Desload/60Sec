using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D collider;
    
    public void ShowelActive()
    {
        collider.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer : MonoBehaviour
{
    public SpriteRenderer render;

    public void SwitchSprite(Sprite sprite)
    {
        render.sprite = sprite;
    }

    private void FixedUpdate()
    {
        if (PlayerController.Instance.MoveVector.y < 0)
        {
            render.sortingOrder = 2;
        }
        else
            render.sortingOrder = 0;
    }
}

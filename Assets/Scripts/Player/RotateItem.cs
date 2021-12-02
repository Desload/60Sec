using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateItem : MonoBehaviour
{
    private PlayerController playerController;

    private void FixedUpdate()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(PlayerController.Instance.MousePosition) - transform.position;

        //Vector2 directionToLookAt = new Vector2(pos.x - transform.position.x, pos.y - transform.position.y);

        //transform.up = directionToLookAt;

        var rotate = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, rotate - 90), 0.4f);
    }
}

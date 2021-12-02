using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraBound : MonoBehaviour
{
    public Transform lookAt;
    private float boundX = 0.15f;
    private float boundY = 0.1f;


    void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        float deltaX = lookAt.position.x - transform.position.x;
        if (Mathf.Abs(deltaX) > boundX)
            if (lookAt.position.x > transform.position.x)
                delta.x = deltaX - boundX;
            else
                delta.x = deltaX + boundX;
        float deltaY = lookAt.position.y - transform.position.y;
        if (Mathf.Abs(deltaY) > boundY)
            if (lookAt.position.y > transform.position.y)
                delta.y = deltaY - boundY;
            else
                delta.y = deltaY + boundY;
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}

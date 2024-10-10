using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour, IRotateable
{

    private Vector3 old = Vector3.zero;

    public void Rotate(in Vector3 vec, in float speed)
    {

        var dir = (vec - old).normalized;
        dir.y = dir.x;
        dir.x = 0;
        transform.eulerAngles += dir * speed * Time.deltaTime;

        old = vec;

    }

}

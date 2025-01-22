using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public float width = 20.46f;

    private void Update()
    {
        if(transform.position.x < -width)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        var pos = transform.position;
        pos.x += width * 2;
        transform.position = pos;
    }
}

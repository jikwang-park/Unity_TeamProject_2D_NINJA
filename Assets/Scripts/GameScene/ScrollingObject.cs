using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
    }

    private void OnGameOver()
    {
        enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 5f;
    public BoxCollider2D collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    private void OnGameover()
    {
        enabled = false;
    }
}

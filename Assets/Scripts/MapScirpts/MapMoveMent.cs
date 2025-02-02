using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoveMent : MonoBehaviour
{
    public float speed = 5f;

  
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    private void OnGameover()
    {
        enabled = false;
    }
}

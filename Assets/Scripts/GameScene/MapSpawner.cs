using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    private float spwanPoint;
    private GameObject target;

    private void Awake()
    {
        

    }

    private void Start()
    {
        var background = GameObject.FindWithTag("Background");
        target = background;
        var targetRenderer = target.GetComponent<SpriteRenderer>();

        float halftargetXsize = targetRenderer.size.x/2;


        var nowTargetPos = transform.position;
        transform.position = new Vector2(nowTargetPos.x+ halftargetXsize, nowTargetPos.y);
    }



    private void Update()
    {
        
    }


}

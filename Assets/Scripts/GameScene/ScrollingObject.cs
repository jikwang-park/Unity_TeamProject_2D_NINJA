using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    public GameObject prefabs;
    public float backGroundWidth;
    public float cameraLeftPos;

    private List<GameObject> backgrounds = new List<GameObject>();


    private void Awake()
    {
        
        var ObjRender = prefabs.GetComponent<SpriteRenderer>();
        backGroundWidth = ObjRender.size.x;

        CreateBackgrounds();

    }

    private void Start()
    {
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight * (Screen.width / Screen.height);
        cameraLeftPos = Camera.main.transform.position.x - screenWidth / 2;

    }

    private void CreateBackgrounds()
    {
        if(backgrounds.Count ==0)
        {
            for (int i = 0; i < 2; i++)
            {
                var posX = transform.position.x + (i * backGroundWidth);
                GameObject newBackground = Instantiate(prefabs, new Vector3(posX, 0, 0), Quaternion.identity);
                backgrounds.Add(newBackground);
            }
        }
  

    }

    private void Update()
    {
        MoveBackgrounds();
    }

    private void MoveBackgrounds()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (backgrounds[i].transform.position.x + backGroundWidth / 2 < cameraLeftPos)
            {
                Repositioning(i);
            }
        }
    }

    private void Repositioning(int i)
    {
        float newXpos = backgrounds[(i + 1) % backgrounds.Count].transform.position.x + backGroundWidth;
        backgrounds[i].transform.position = new Vector3(newXpos, 0,0);
    }

    private void OnGameOver()
    {
        enabled = false;
    }
}

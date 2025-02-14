using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    public float speed = 10f;

    public GameObject[] objs;
    public float backGroundWidth;
    public float cameraLeftPos;

    public float backGroundChangeTimer = 15f;
    public float CurrnetTime;

    private List<GameObject> backgrounds = new List<GameObject>();

    
    private void Awake()
    {
        //¿¹ºñ¿ë
        var SpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        backGroundWidth = SpriteRenderer.size.x;

        CreateBackgrounds();

    }


    //private void BackgroundSpirteChange()
    //{
    //    CurrnetTime += Time.deltaTime;
    //    if(CurrnetTime >= backGroundChangeTimer)
    //    {
    //        ChangeBackground();
    //    }
        
    //}

    //private void ChangeBackground()
    //{

    //}

    private void Start()
    {
        float screenHeight = Camera.main.orthographicSize * 2;
        float screenWidth = screenHeight * (Screen.width / Screen.height);
        cameraLeftPos = Camera.main.transform.position.x - screenWidth / 2;
    }

    private void CreateBackgrounds()
    {
        if (backgrounds.Count == 0)
        {

            var cam = Camera.main;
            var camleftpos = cam.ViewportToWorldPoint(Vector3.zero);

            var firstpos = transform.position;
            firstpos.x = camleftpos.x;
            transform.position = firstpos;

            backgrounds.Add(gameObject);
            for (int i = 0; i < objs.Length; i++)
            {
                var pos = objs[i].transform.position;
                pos.x = firstpos.x + backGroundWidth * (i + 1);
                objs[i].transform.position = pos;

                backgrounds.Add(objs[i]);
            }
        }
    }

    private void Update()
    {
        MoveBackgrounds();
    }

    private void MoveBackgrounds()
    {
        Camera selectedCamera = Camera.main;
        for (int i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        for (int i = 0; i < backgrounds.Count; i++)
        {
            var pos = backgrounds[i].transform.position;
            pos.x += backGroundWidth;
            Vector3 screenPoint = selectedCamera.WorldToViewportPoint(pos);
            bool onScreen = screenPoint.x > 0;

            if (!onScreen)
            {
                Repositioning(i);
            }
        }
    }

    private void Repositioning(int i)
    {
        float newXpos = backgrounds[(i + backgrounds.Count - 1) % backgrounds.Count].transform.position.x + backGroundWidth;
        backgrounds[i].transform.position = new Vector3(newXpos, 0, 0);
    }

    private void OnGameOver()
    {
        enabled = false;
    }
}

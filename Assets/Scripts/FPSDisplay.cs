using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 999;
    }
    public TextMeshProUGUI fpsText;
    private float deltatime = 0.0f;
    private void Update()
    {
        deltatime += (Time.unscaledDeltaTime - deltatime) * 0.1f;
    }

    // Update is called once per frame
    private void OnGUI()
    {
        if(fpsText != null)
        {
            float fps = 1.0f / deltatime;
            fpsText.text = "FPS: " + Mathf.Ceil(fps).ToString();
        }
    }
}

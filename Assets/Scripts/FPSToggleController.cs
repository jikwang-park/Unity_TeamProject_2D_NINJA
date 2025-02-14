using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSToggleController : MonoBehaviour
{


    public FPSDisplay fpsDisplay;  // FPS 표시 스크립트 참조
    public Toggle fpsToggle;  // FPS 표시 토글

    void Start()
    {
        // Toggle 상태 변경 시 FPS 표시 ON/OFF 제어
        fpsToggle.onValueChanged.AddListener(ToggleFPSDisplay);
    }

    void ToggleFPSDisplay(bool isOn)
    {
        if (fpsDisplay != null)
        {
            fpsDisplay.gameObject.SetActive(isOn);  // FPS 표시 활성화/비활성화
        }
    }

}

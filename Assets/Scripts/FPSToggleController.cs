using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSToggleController : MonoBehaviour
{


    public FPSDisplay fpsDisplay;  // FPS ǥ�� ��ũ��Ʈ ����
    public Toggle fpsToggle;  // FPS ǥ�� ���

    void Start()
    {
        // Toggle ���� ���� �� FPS ǥ�� ON/OFF ����
        fpsToggle.onValueChanged.AddListener(ToggleFPSDisplay);
    }

    void ToggleFPSDisplay(bool isOn)
    {
        if (fpsDisplay != null)
        {
            fpsDisplay.gameObject.SetActive(isOn);  // FPS ǥ�� Ȱ��ȭ/��Ȱ��ȭ
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneGameManager : MonoBehaviour
{
    public StartUiManager uiManager;
    private void Awake()
    {
        
    }
    private void Start()
    {
        uiManager.gameStartButton.onClick.AddListener(() => OnClickStartButton());
        uiManager.gameLoadButton.onClick.AddListener(() => OnClickLoadButton());
        uiManager.gameExitButton.onClick.AddListener(() => OnClickExitButton());
    }

    private void OnClickStartButton()
    {
        SceneManager.LoadScene((int)ScenesIds.MainTitleScene);
    }

    private void OnClickExitButton()
    {

    }

    private void OnClickLoadButton()
    {

    }
}

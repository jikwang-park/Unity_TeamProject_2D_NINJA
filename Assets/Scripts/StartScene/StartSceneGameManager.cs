using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
        uiManager.gameExitButton.onClick.AddListener(() => OnClickExitButton());
        uiManager.CharSelectButton.onClick.AddListener(() => OnClickCharSelect());
    }

    private void OnClickCharSelect()
    {
        SceneManager.LoadScene((int)ScenesIds.CharacterSelectScene);
    }

    private void OnClickStartButton()
    {
        SceneManager.LoadScene((int)ScenesIds.InfinityModeScene);
    }



    private void OnClickExitButton()
    {
        Application.Quit();

    }
}

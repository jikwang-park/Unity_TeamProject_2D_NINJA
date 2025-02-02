using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfinityModeGameManager : MonoBehaviour
{
    public InfinityModeUiManager uiManager;

    public GameObject target;

    private float originalTime;

    private GameState gameState;


    private void Awake()
    {
       
    }
    private void Start()
    {
        originalTime = Time.timeScale;


        target.SetActive(false);


        uiManager.StopButton.onClick.AddListener(() => OnClickStopButton());
        uiManager.reStartButton.onClick.AddListener(() => OnClickReStartButton());
        uiManager.continueButton.onClick.AddListener(()=> OnClickContinueButton());
        uiManager.exitButton.onClick.AddListener(()=> OnClickExitButton());
    }

   


    private void OnClickStopButton()
    {
        Time.timeScale = 0f;

        

        target.SetActive(true);

        Button[] buttons = { uiManager.jumpButton, uiManager.smallButton,uiManager.StopButton };
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false);
        }

    }


    private void OnClickReStartButton()
    {
        target.SetActive(false);



        Button[] buttons = { uiManager.jumpButton, uiManager.smallButton,uiManager.StopButton };
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    private void OnClickContinueButton()
    {
        Time.timeScale = originalTime;

        target.SetActive(false);

      

        Button[] buttons = { uiManager.jumpButton, uiManager.smallButton, uiManager.StopButton };
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    private void OnClickExitButton()
    {
        target.SetActive(false);


        

        Button[] buttons = { uiManager.jumpButton, uiManager.smallButton, uiManager.StopButton };
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(true);
        }
        SceneManager.LoadScene((int)ScenesIds.MainTitleScene);
        Time.timeScale = originalTime; 
    }
}

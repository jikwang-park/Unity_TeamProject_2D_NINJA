using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTitleGameManager : MonoBehaviour
{
    public bool CanContinue = true;


    public MainTitleUiManager uiManager;

    protected SceneSelectManager sceneSelectManager;
    private void Start()
    {
        if(uiManager != null)
        {
            uiManager.gameStartButton.onClick.AddListener(() => OnClickGameStart());
            uiManager.charSelectButton.onClick.AddListener(() => OnClickCharSelect());
        }
        else
        {
            Debug.Log("MainButton is Null");
        }
        
        
    }
    public void Init(SceneSelectManager mgr)
    {
        sceneSelectManager = mgr;
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void OnClickGameStart()
    {

        SceneManager.LoadScene((int)ScenesIds.InfinityModeScene);
    }


    private void OnClickCharSelect()
    {
        SceneManager.LoadScene((int)ScenesIds.CharacterSelectScene);
    }

    
}

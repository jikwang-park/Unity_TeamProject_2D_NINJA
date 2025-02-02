using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTitleGameManager : MonoBehaviour
{
    public bool CanContinue = true;

    public GameObject firstSelected;

    public MainTitleUiManager uiManager;

    protected SceneSelectManager sceneSelectManager;
    private void Start()
    {
        if(uiManager != null)
        {
            uiManager.infinityModeButton.onClick.AddListener(() => OnClickInfinityMode());
            uiManager.storyModeButton.onClick.AddListener(() => OnClickStoryMode());
            uiManager.characterSelectButton.onClick.AddListener(() => OnClickCharacterSelect());
            uiManager.weaponSelectButton.onClick.AddListener(() => OnClickWeaponSelect());
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

    private void OnClickInfinityMode()
    {
        SceneManager.LoadScene((int)ScenesIds.InfinityModeScene);
    }

    private void OnClickStoryMode()
    {
        SceneManager.LoadScene((int)ScenesIds.StoryModeScene);
    }

    private void OnClickCharacterSelect()
    {
        SceneManager.LoadScene((int)ScenesIds.CharacterSelectScene);
    }

    private void OnClickWeaponSelect()
    {
        SceneManager.LoadScene((int)ScenesIds.WeaponSelectScene);
    }
}

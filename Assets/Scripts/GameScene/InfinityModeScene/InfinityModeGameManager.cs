using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfinityModeGameManager : MonoBehaviour
{
    public InfinityModeUiManager uiManager;

    public AudioClip[] sounds;

    private AudioSource audioSource;

    private float originalTime;

    private GameState gameState;

    public Player player;

    public Transform spawnPoint;


    private void Awake()
    {
        PlayerSpawn();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        originalTime = Time.timeScale;

        uiManager.targetObj.SetActive(false);
        player.OnSizeChanged.AddListener(uiManager.SetSkillButton);
        
        uiManager.manager = player.GetComponent<PlayerSkillManager>();
        
        uiManager.StopButton.onClick.AddListener(() => OnClickStopButton());
        uiManager.reStartButton.onClick.AddListener(() => OnClickReStartButton());
        uiManager.continueButton.onClick.AddListener(()=> OnClickContinueButton());
        uiManager.exitButton.onClick.AddListener(()=> OnClickExitButton());
        uiManager.resultRetryButton.onClick.AddListener(() => OnClickRetryButton());
        uiManager.resultExitButton.onClick.AddListener(() => OnClickResultExitButton());
    }

    private void OnClickResultExitButton()
    {
        SceneManager.LoadScene((int)ScenesIds.StartScene);
        Time.timeScale = 1;
    }

    private void OnClickRetryButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.animator.updateMode = AnimatorUpdateMode.Normal;
    }

    public void PlayerSpawn()
    {
        if (GameManager.Instance.Id == null)
        {
            GameManager.Instance.Id = "Player1";
            SettingData();
        }
        else
        {
            SettingData();
        }
    }

    public void SettingData()
    {
        var playerData = DataTableManager.PlayerStateTable.Get(GameManager.Instance.Id);
        var Player = Instantiate(playerData.PlayerPrefab, spawnPoint.transform.position, Quaternion.identity);
        player = Player.GetComponent<Player>();
        player.Init(playerData.Id, playerData.MaxHp, playerData.AttackDamage, playerData.Experience);
    }


    private void OnClickStopButton()
    {

        if (!player.isAlive)
            return;
        SetButtonSound();
        uiManager.targetObj.SetActive(true);
        foreach (var button in uiManager.ingameButton)
        {
            button.gameObject.SetActive(false);
        }
        Time.timeScale = 0f;

        

        

    }


    private void OnClickReStartButton()
    {
        SetButtonSound();

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.animator.updateMode = AnimatorUpdateMode.Normal;

        
        
    }

    private void OnClickContinueButton()
    {
        if (!player.isAlive)
            return;
        SetButtonSound();

        uiManager.targetObj.SetActive(false);
        foreach (var button in uiManager.ingameButton)
        {
            button.gameObject.SetActive(true);
        }

        Time.timeScale = 1f;

     
    }

    private void OnClickExitButton()
    {
        SetButtonSound();

        uiManager.targetObj.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene((int)ScenesIds.StartScene);
        
    }
   
    public void SetGameoverSound()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(sounds[(int)SoundsId.Gameover]);
    }

    public void SetJumpSound()
    {
        audioSource.loop = false;

        audioSource.PlayOneShot(sounds[(int)SoundsId.Jumpsound]);
    }

    public void SetButtonSound()
    {
        audioSource.loop = false;

        audioSource.PlayOneShot(sounds[(int)SoundsId.ButtonClick]);
        Invoke("StopSound", 1f);

    }

    

    public void SetPlayerHitSound()
    {
        audioSource.loop = false;

        audioSource.PlayOneShot(sounds[(int)SoundsId.PlayerHit]);
    }

    public void SetBigSkillSound()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(sounds[(int)SoundsId.SkillExplosion]);
    }
    public void SetSkillSmallSound()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(sounds[(int)SoundsId.SkillShiled]);

    }
    public void SetSkillMiddleSound()
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(sounds[(int)SoundsId.SkillSwordPoll]);
    }

    private void StopSound()
    {
        audioSource.Stop();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class InfinityModeUiManager : MonoBehaviour
{
    public PlayerMovement player;
    public PlayerSkillManager manager;

    public GameObject gameoverText;

    public TextMeshProUGUI scoreText;
    private int scoreCount;

    private float addScoreTime = 1f;

    public Image skillImage;
    private float coolTime = 15f;
    private bool isCoolTime = false;


    public Button jumpButton;
    public Button smallButton;
    public Button bigButton;
    public Button StopButton;
    public Button groundImpactButton;
    public Button sowrdShiledButton;
    public Button swordPollButton;

    public Button reStartButton;
    public Button continueButton;
    public Button exitButton;

    public SkillButtons[] skillButtons;


    private void Awake()
    {
        gameoverText.SetActive(false);
        jumpButton.onClick.AddListener(OnClickJumpButton);
        smallButton.onClick.AddListener(OnClickSmall);
        bigButton.onClick.AddListener(OnClickBig);
        groundImpactButton.onClick.AddListener(OnClickGroundImpact);
        sowrdShiledButton.onClick.AddListener(OnClickSwordShiled);
        swordPollButton.onClick.AddListener(OnSkillSwordPoll);
        player.OnSizeChanged.AddListener(SetSkillButton);
        scoreText.text = $"SCORE: {scoreCount}";
    }



    private void Update()
    {
        UpdateGameover();
        SetScore();
    }

    private void SetScore()
    {

        if (player.isAlive && Time.timeScale > 0)
        {
            scoreCount += 400;
            scoreText.text = $"SCORE: {scoreCount}";
        }
        else
        {
            scoreText.text = $"SCORE: {scoreCount}";
        }


    }
    private void UpdateGameover()
    {
        if (!player.isAlive)
        {
            gameoverText.SetActive(true);
        }
    }
    private void OnClickSwordShiled()
    {
        if (isCoolTime)
            return;
        isCoolTime = true;

        StartCoroutine(EndcoolTime(sowrdShiledButton, 25f));
        Debug.Log("Shield");
        manager.SkillSwordShiled();
    }
    private void OnSkillSwordPoll()
    {
        if (isCoolTime)
            return;
        isCoolTime = true;
        StartCoroutine(EndcoolTime(swordPollButton, 20f));
        Debug.Log("Sword");

        manager.SkillSwordPoll();
    }
    private void OnClickGroundImpact()
    {
        if (isCoolTime)
            return;
        isCoolTime = true;
        Debug.Log("Impact");
        StartCoroutine(EndcoolTime(groundImpactButton, 18f));

        manager.SkillGroundImpact();
    }

    public IEnumerator EndcoolTime(Button button, float timer)
    {
        yield return new WaitForSeconds(timer);
        isCoolTime = false;

        button.interactable = true;
    }

    private void OnClickBig()
    {
        player.Big();
    }

    private void OnClickJumpButton()
    {
        player.Jump();
    }

    private void OnClickSmall()
    {
        player.Small();
    }

    private void SetSkillButton()
    {
        isCoolTime = false;
        foreach (var button in skillButtons)
        {
            //버튼을 아예 표시하지 않음
            button.gameObject.SetActive(button.targetState == player.CurrentState);
            //버튼의 반응만 죽임
            //button.interactable
        }
    }
}

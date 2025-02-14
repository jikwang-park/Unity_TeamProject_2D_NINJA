using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Rendering.Universal;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
public class InfinityModeUiManager : MonoBehaviour 
{
    public InfinityModeGameManager gameManager;
    public PlayerSkillManager manager;

    public GameObject gameoverText;
    public GameObject targetObj;
    public GameObject ResultObj;

    public TextMeshProUGUI ScoreboardResultScore;
    public TextMeshProUGUI optionResultText;
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI inGameScoreText;

    private int scoreCount;
    private int pointPerSecond = 20000;
    private float targetScore = 0;
    private int currentScore = 0;
    private float addScoreTime = 1f;

    public Image skillImage;
    private float coolTime = 15f;
    private bool isSmallCoolTime = false;
    private bool isBigCoolTime = false;
    private bool isMiddleCoolTime = false;

    private SpriteRenderer renderer;
    private Animator animator;

    public Slider healthSlider;
    private float currentHealth;
    public Slider ExpSlider;
    private float currentExp;

    public Button jumpButton;
    public Button smallButton;
    public Button bigButton;
    public Button StopButton;
    public Button groundImpactButton;
    public Button swordShiledButton;
    public Button swordPollButton;

    public Button[] ingameButton;

    public Button reStartButton;
    public Button continueButton;
    public Button exitButton;

    public Button resultRetryButton;
    public Button resultExitButton;

    public float currentTime;

    public SkillButtons[] skillButtons;

    //스킬쿨타임
    public TextMeshProUGUI shiledCooltimeText;
    public TextMeshProUGUI pollCooltimeText;
    public TextMeshProUGUI impactCooltimeText;

    private void Awake()
    {
    }
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();
        gameoverText.SetActive(false);
        ////jumpButton.onClick.AddListener(OnClickJumpButton);
        smallButton.onClick.AddListener(OnClickSmall);
        bigButton.onClick.AddListener(OnClickBig);
        groundImpactButton.onClick.AddListener(OnClickGroundImpact);
        swordShiledButton.onClick.AddListener(OnClickSwordShiled);
        swordPollButton.onClick.AddListener(OnSkillSwordPoll);
        renderer = gameManager.player.GetComponent<SpriteRenderer>();
        animator = gameManager.player.GetComponent<Animator>();
        optionResultText.text = $"SCORE: {scoreCount}";
        SetOnFirstSlider();
        SetOnFirstExpSilder();
        targetObj.SetActive(false);
        ResultObj.SetActive(false);
    }



    private void Update()
    {
        UpdateUi();
    }

    private void UpdateUi()
    {
        SetScore();
        SetSilder();
        SetExpSlider();
        SetHpText();
        SetLevel();
        SetExpText();
    }
    private void SetOnFirstExpSilder()
    {
        currentExp = gameManager.player.currentExp;
        ExpSlider.maxValue = gameManager.player.maxExpGage;
        ExpSlider.value = currentExp;
    }

    public void SetExpSilderMax()
    {
        ExpSlider.maxValue = gameManager.player.maxExpGage;
    }
    public void SetExpSlider()
    {
        currentExp = gameManager.player.currentExp;
        ExpSlider.value = currentExp;
    }

    private void SetOnFirstSlider()
    {
        currentHealth = gameManager.player.currentHp;
        healthSlider.maxValue = gameManager.player.playerMaxHp;
        healthSlider.value = currentHealth;
    }
    public void SetSliderMax()
    {
        healthSlider.maxValue = gameManager.player.playerMaxHp;
    }

    public void SetSilder()
    {
        currentHealth = gameManager.player.currentHp;
        healthSlider.value = currentHealth;
    }
    private void SetScore()
    {
        targetScore = pointPerSecond * Time.timeSinceLevelLoad;

        if (currentScore < targetScore)
        {
            currentScore += (int)(pointPerSecond * Time.deltaTime);

            if (currentScore > targetScore)
                currentScore = (int)targetScore;
        }


        optionResultText.text = $" : {currentScore}";
        inGameScoreText.text = $" {currentScore}";
        ScoreboardResultScore.text = $"SCORE : {currentScore}";
    }

    private void SetExpText()
    {
        expText.text = $" EXP : {gameManager.player.currentExp}/{gameManager.player.maxExpGage}";
    }
    private void SetLevel()
    {
        levelText.text = $"LV :{gameManager.player.levelcount}";
    }
    private void SetHpText()
    {
        HpText.text = $"HP: {gameManager.player.currentHp} / {gameManager.player.playerMaxHp}";
    }
    public void UpdateGameover()
    {

        StartCoroutine(PlayerDead());

    }
    private void OnClickSwordShiled()
    {
        if (isSmallCoolTime)
            return;
        gameManager.SetSkillSmallSound();
        isSmallCoolTime = true;
        //임시코드
        gameManager.player.currentHp -= 2;
        SetSilder();

        StartCoroutine(EndSmallCoolTime(swordShiledButton, 25f));
        Debug.Log("Shield");
        manager.SkillSwordShiled();
    }
    private void OnSkillSwordPoll()
    {
        if (isMiddleCoolTime)
            return;
        gameManager.SetSkillMiddleSound();
        isMiddleCoolTime = true;
        //임시코드
        gameManager.player.currentHp -= 1;

        StartCoroutine(EndMiddleCoolTime(swordPollButton, 20f));
        Debug.Log("Sword");

        manager.SkillSwordPoll();
    }
    private void OnClickGroundImpact()
    {

        if (isBigCoolTime)
            return;
        gameManager.SetBigSkillSound();
        isBigCoolTime = true;
        //임시코드
        gameManager.player.currentHp -= 3;

        Debug.Log("Impact");
        StartCoroutine(EndBigCoolTime(groundImpactButton, 18f));

        manager.SkillGroundImpact();
    }

    //private void SetCoolTimeText()
    //{
    //    var state = gameManager.player.CurrentState;
    //    switch (state)
    //    {
    //        case Player.CharacterState.small:
    //            shiledCooltimeText.gameObject.SetActive(true);
    //            pollCooltimeText.gameObject.SetActive(false);
    //            impactCooltimeText.gameObject.SetActive(false);
    //            break;
    //        case Player.CharacterState.middle:
    //            shiledCooltimeText.gameObject.SetActive(false);
    //            pollCooltimeText.gameObject.SetActive(true);
    //            impactCooltimeText.gameObject.SetActive(false);
    //            break;
    //        case Player.CharacterState.big:
    //            shiledCooltimeText.gameObject.SetActive(false);
    //            pollCooltimeText.gameObject.SetActive(false);
    //            impactCooltimeText.gameObject.SetActive(true);
    //            break;
    //    }

    //}

    public IEnumerator EndSmallCoolTime(Button button, float timer)
    {
        float currentTime = 0f;
        while (currentTime < timer)
        {
            currentTime += Time.deltaTime;


            if (gameManager.player.CurrentState == Player.CharacterState.small)
            {
                if (!shiledCooltimeText.gameObject.activeSelf)
                {
                    shiledCooltimeText.gameObject.SetActive(true);
                }


                shiledCooltimeText.text = Mathf.Ceil(timer - currentTime).ToString();
            }
            else
            {
                shiledCooltimeText.gameObject.SetActive(false);
            }

            yield return null;
        }

        isSmallCoolTime = false;
        shiledCooltimeText.gameObject.SetActive(false);
        button.interactable = true;
    }
    //public IEnumerator EndSmallCoolTime(Button button, float timer)
    //{
    //    //float currentTime = 0f;
    //    //while (currentTime < timer)
    //    //{
    //    //    currentTime += Time.deltaTime;

    //    //    if(shiledCooltimeText != null)
    //    //    {
    //    //        shiledCooltimeText.text = Mathf.Ceil(timer - currentTime).ToString();
    //    //    }

    //    //    yield return null;
    //    //}
    //    //if(shiledCooltimeText != null)
    //    //{
    //    //    shiledCooltimeText.text = "0";
    //    //    shiledCooltimeText.gameObject.SetActive(false);
    //    //}
    //    //isSmallCoolTime = false;

    //    yield return new WaitForSeconds(timer);
    //    isSmallCoolTime = false;

    //    button.interactable = true;
    //}

    //public IEnumerator EndBigCoolTime(Button button, float timer)
    //{
    //    //float currentTime = 0f;
    //    //while (currentTime < timer)
    //    //{
    //    //    currentTime += Time.deltaTime;

    //    //    if (impactCooltimeText != null)
    //    //    {
    //    //        impactCooltimeText.text = Mathf.Ceil(timer - currentTime).ToString();
    //    //    }

    //    //    yield return null;
    //    //}
    //    //if (impactCooltimeText != null)
    //    //{
    //    //    impactCooltimeText.text = "0";
    //    //    impactCooltimeText.gameObject.SetActive(false);

    //    //}
    //    yield return new WaitForSeconds(timer);
    //    isBigCoolTime = false;
    //    button.interactable = true;
    //}
    public IEnumerator EndBigCoolTime(Button button, float timer)
    {
        float currentTime = 0f;
        while (currentTime < timer)
        {
            currentTime += Time.deltaTime;


            if (gameManager.player.CurrentState == Player.CharacterState.big)
            {
                if (!impactCooltimeText.gameObject.activeSelf)
                {
                    impactCooltimeText.gameObject.SetActive(true);
                }


                impactCooltimeText.text = Mathf.Ceil(timer - currentTime).ToString();
            }
            else
            {
                impactCooltimeText.gameObject.SetActive(false);
            }

            yield return null;
        }

        isBigCoolTime = false;
        impactCooltimeText.gameObject.SetActive(false);
        button.interactable = true;
    }
    public IEnumerator EndMiddleCoolTime(Button button, float timer)
    {
        float currentTime = 0f;
        while (currentTime < timer)
        {
            currentTime += Time.deltaTime;


            if (gameManager.player.CurrentState == Player.CharacterState.middle)
            {
                if (!pollCooltimeText.gameObject.activeSelf)
                {
                    pollCooltimeText.gameObject.SetActive(true);
                }


                pollCooltimeText.text = Mathf.Ceil(timer - currentTime).ToString();
            }
            else
            {
                pollCooltimeText.gameObject.SetActive( false);
            }

            yield return null;
        }

        isMiddleCoolTime = false;
        pollCooltimeText.gameObject.SetActive(false);
        button.interactable = true;
    }
    ////public IEnumerator EndMiddleCoolTime(Button button, float timer)
    ////{
    ////    //float currentTime = 0f;
    ////    //while (currentTime < timer)
    ////    //{
    ////    //    currentTime += Time.deltaTime;

    ////    //    if (pollCooltimeText != null)
    ////    //    {
    ////    //        pollCooltimeText.text = Mathf.Ceil(timer - currentTime).ToString();
    ////    //    }

    ////    //    yield return null;
    ////    //}
    ////    //if (pollCooltimeText != null)
    ////    //{
    ////    //    pollCooltimeText.text = "0";
    ////    //    pollCooltimeText.gameObject.SetActive(false);

    ////    //}
    ////    yield return new WaitForSeconds(timer);
    ////    isMiddleCoolTime = false;
    ////    button.interactable = true;
    ////}

    public IEnumerator PlayerDead()
    {
        gameoverText.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        gameoverText.SetActive(false);
        ResultObj.SetActive(true);
    }

    private void OnClickBig()
    {
        if (!gameManager.player.isAlive)
            return;
        //SetCoolTimeText();
        gameManager.player.Big();
    }

    //private void OnClickJumpButton()
    //{
    //    gameManager.player.Jump();
    //}

    private void OnClickSmall()
    {
        if(!gameManager.player.isAlive)
            return;
        //SetCoolTimeText();
        gameManager.player.Small();
    }

    public void SetSkillButton()
    {
        foreach (var button in skillButtons)
        {
            //버튼을 아예 표시하지 않음
            button.gameObject.SetActive(button.targetState == gameManager.player.CurrentState);
            //버튼의 반응만 죽임
            //button.interactable
        }
    }
    public void DisplayDamageUI()
    {
        if (ResetColorAfterHit() != null)
        {
            StopCoroutine(ResetColorAfterHit());
        }
        Color currentColor = renderer.color;
        currentColor.a = 0.5f;
        renderer.color = currentColor;

        // 피격 후 원래 색상으로 돌아오는 코루틴
        StartCoroutine(ResetColorAfterHit());
    }
    public IEnumerator ResetColorAfterHit()
    {
        yield return new WaitForSeconds(1f);
        Color currentColor = renderer.color;
        currentColor.a = 1f;
        renderer.color = currentColor;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiManager : MonoBehaviour
{
    public PlayerMovement player;

    public GameObject gameoverText;
    public Button jumpButton;
    public Button topDownButton;
    public TextMeshProUGUI scoreText;
    private int scoreCount;

    private float addScoreTime = 1f;


    private void Awake()
    {
        gameoverText.SetActive(false);
        jumpButton.onClick.AddListener(OnClickJumpButton);
        topDownButton.onClick.AddListener(OnClickTopDownButton);

        scoreText.text = $"SCORE: {scoreCount}";
    }

    private void Update()
    {
        UpdateGameover();
        SetScore();
    }

    private void SetScore()
    {
        if(player.isAlive)
        {
            scoreCount += 400;
            scoreText.text = $"SCORE: {scoreCount}";
        }
        else
        {
            scoreText.gameObject.SetActive(false);
        }
        

    }
    private void UpdateGameover()
    {
        if (!player.isAlive)
        {
            gameoverText.SetActive(true);
        }
    }

    private void OnClickJumpButton()
    {
        player.Jump();
    }

    private void OnClickTopDownButton()
    {
        player.Filp();
    }
}

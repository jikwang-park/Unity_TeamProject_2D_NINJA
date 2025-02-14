using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectUi : MonoBehaviour
{
    public Button player1Button;
    public Button player2Button;
    public Button player3Button;

    private void Start()
    {
        player1Button.onClick.AddListener(StartOnPlayer1);
        player2Button.onClick.AddListener(StartOnPlayer2);
        player3Button.onClick.AddListener(StartOnPlayer3);

    }

    private void StartOnPlayer1()
    {
        GameManager.Instance.DataClear();
        GameManager.Instance.Id = "Player1";
        SceneManager.LoadScene((int)ScenesIds.StartScene);
    }

    private void StartOnPlayer2()
    {
        GameManager.Instance.DataClear();
        GameManager.Instance.Id = "Player2";
        Debug.Log(GameManager.Instance.Id);
        SceneManager.LoadScene((int)ScenesIds.StartScene);

    }
    private void StartOnPlayer3()
    {
        GameManager.Instance.DataClear();
        GameManager.Instance.Id = "Player3";
        SceneManager.LoadScene((int)ScenesIds.StartScene);
    }
}

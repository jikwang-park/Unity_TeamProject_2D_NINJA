using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public PlayerMovement player;
    public Button jumpButton;
    public Button topDownButton;

    private void Awake()
    {
        jumpButton.onClick.AddListener(OnClickJumpButton);
        topDownButton.onClick.AddListener(OnClickTopDownButton);
    }



    private void OnClickJumpButton()
    {
        player.Jump();
    }

    private void OnClickTopDownButton()
    {
        player.Flip();
    }
}

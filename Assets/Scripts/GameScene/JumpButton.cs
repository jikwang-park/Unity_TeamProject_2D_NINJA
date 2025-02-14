using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour , IPointerDownHandler
{
    public InfinityModeGameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();
    }
    private void Start()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {

            gameManager.player.Jump();
        
        
    }
}

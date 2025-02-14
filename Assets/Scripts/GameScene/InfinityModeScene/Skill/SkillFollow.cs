using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFollow : MonoBehaviour
{
    public Transform following;
    private InfinityModeGameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();
        following = gameManager.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

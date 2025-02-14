using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    private Collider2D col;
    
   
    public override void Init(string id,float amount)
    {
        this.id = id;
        this.amount = amount;
    }
    private void Start()
    {
        col = GetComponent<Collider2D>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();
    }
    
    private void EatPosion(int value)
    {
        
        value = (int)amount;
        manager.player.currentHp += value;
        manager.uiManager.SetSilder();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if(collsion.CompareTag("Player")&& col.IsTouching(collsion))
        {
            EatPosion((int)amount);
        }
    }
}
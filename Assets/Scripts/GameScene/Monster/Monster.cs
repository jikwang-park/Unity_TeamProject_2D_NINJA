using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected string id;
    protected float currentHp;
    protected float maxHp;
    protected float attackDamage;
    protected InfinityModeGameManager gameManager;

    public virtual void Init(string id , float maxhp, float attackDamage)
    {
        this.id = id;
        this.maxHp = maxhp;
        this.attackDamage = attackDamage;
    }

    public virtual void TakeDamage(float damage)
    {
        var player = gameManager.player;
    }

    
}

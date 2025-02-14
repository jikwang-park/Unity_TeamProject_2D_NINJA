using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected string id;
    protected float amount;
    
    protected InfinityModeGameManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();
    }

    public virtual void Init(string id,float amount)
    {
        this.id = id;
        this.amount = amount;
    }
}

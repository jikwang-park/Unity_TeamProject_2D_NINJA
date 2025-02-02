using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingSwordPoll : PlayerUseSkill
{
    public Vector2 boxSize = new Vector2(1000f, 1f);
    public float rayLenght = 5f;

    public override void ActiveSkill()
    {
        var hitArray = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, LayerMask.GetMask("Obstacle"));

        foreach (var hit in hitArray)
        {
            hit.gameObject.SetActive(false);
        }
    }
}

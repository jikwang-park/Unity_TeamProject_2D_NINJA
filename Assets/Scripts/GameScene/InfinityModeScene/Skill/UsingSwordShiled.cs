using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingSwordSiled : PlayerUseSkill
{
    public CircleCollider2D collider;

    private void Start()
    {
        collider.gameObject.SetActive(false);
    }
    public override void ActiveSkill()
    {
        collider.gameObject.SetActive(true);

        StartCoroutine(CircleColliderCoolTime(5f));
    }
    public IEnumerator CircleColliderCoolTime(float timer)
    {
        int count = -1;
        WaitForSeconds wait = new WaitForSeconds(timer / 50);
        while (++count < 50)
        {
            var targets = Physics2D.OverlapCircleAll(
                collider.transform.position, collider.radius, LayerMask.GetMask("Obstacle"));
            foreach (var target in targets)
            {
                target.gameObject.SetActive(false);
            }
            yield return wait;
        }

        collider.gameObject.SetActive(false);

    }
}

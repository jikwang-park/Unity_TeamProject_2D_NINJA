using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingSwordSiled : PlayerUseSkill
{
    public CircleCollider2D collider;
    public ParticleSystem particle;
    protected override void Start()
    {
        base.Start();
        particle = GetComponent<ParticleSystem>();
        collider.gameObject.SetActive(false);
        particle.Stop();
    }
    public override void ActiveSkill()
    {
        collider.gameObject.SetActive(true);

        StartCoroutine(CircleColliderCoolTime(3f));
    }
    public IEnumerator CircleColliderCoolTime(float timer)
    {
        int count = -1;
        WaitForSeconds wait = new WaitForSeconds(timer / 30);
        particle.Play();
        while (++count < 30 && gameManager.player.CurrentState == Player.CharacterState.small)
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
        particle.Stop();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class UsingSwordPoll : PlayerUseSkill
{
    public Vector2 boxSize = new Vector2(1000f, 1f);
    public float rayLenght = 5f;
    public ParticleSystem particle;
  
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
    }
    protected virtual void Start()
    {
        base.Start();
    }
    public override void ActiveSkill()
    {
        StartCoroutine(UsePoll(1.0f));
    }
    
    private IEnumerator UsePoll(float timer)
    {
        particle.Play();
        int count = -1;
        WaitForSeconds wait = new WaitForSeconds(timer / 10);
        particle.Play();
        while (++count < 10 && gameManager.player.CurrentState == Player.CharacterState.middle)
        {
            var hitArray = Physics2D.OverlapBoxAll(transform.position, boxSize, 0f, LayerMask.GetMask("Obstacle"));

            foreach (var hit in hitArray)
            {
                hit.gameObject.SetActive(false);
            }
            yield return wait;
        }

       

        particle.Stop();
    }
}

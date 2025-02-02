using System.Collections;
using UnityEngine;

public class UsingGroundImpact : PlayerUseSkill
{
    public BoxCollider2D coillder;

    private void Start()
    {
        coillder.gameObject.SetActive(false);
    }
    public override void ActiveSkill()
    {
        coillder.gameObject.SetActive(true);

        StartCoroutine(BoxColliderCoolTime(3.5f));
    }

    public IEnumerator BoxColliderCoolTime(float timer)
    {
        int count = -1;
        WaitForSeconds wait = new WaitForSeconds(timer / 35);
        while (++count < 35)
        {
            var targets = Physics2D.OverlapBoxAll(
          coillder.transform.position, coillder.size, 0, LayerMask.GetMask("Obstacle"));
            foreach (var target in targets)
            {
                target.gameObject.SetActive(false);
            }
            yield return wait;

        }
        coillder.gameObject.SetActive(false);
    }
}

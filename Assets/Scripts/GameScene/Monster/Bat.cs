using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bat : Monster
{
    private Rigidbody2D rb;
    public float flyingSpeed;
    public override void Init(string id, float maxhp, float attackDamage)
    {
        this.id = id;
        this.maxHp = maxhp;
        this.attackDamage = attackDamage;
        flyingSpeed = -10f;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }
    private void Move()
    {
        var currentPos = rb.transform.position;
        var movePos = currentPos.x + Time.deltaTime * flyingSpeed;
        Vector3 newPos = new Vector3(movePos, currentPos.y, currentPos.z);
        rb.transform.position = newPos;
    }
    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MonsterDeadSpot"))
        {
            StartCoroutine(DestroyMonster());
        }
    }
    private IEnumerator DestroyMonster()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}


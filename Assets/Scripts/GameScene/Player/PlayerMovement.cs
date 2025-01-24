using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject target;

    private CapsuleCollider2D playercolldier;
    private PlatformMovement platform;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;


    public float gravScale = 2f;


    public float jumpStr = 20f;
    private int maxJumpCount = 2;
    private int currentJumpCount = 0;

    public float playerHp = 10;

    private float gravPower;


    private bool isGrounded = true;
    public bool isAlive = true;
    private bool isFlipped = false;

    //트리거쪽 함수





    public float enhancedGravityScale = 0.5f;

    //
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        playercolldier = GetComponent<CapsuleCollider2D>();
        spriterenderer = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        gravPower = rb.gravityScale;
        
    }


    private void Update()
    {
        if (playerHp <= 0)
        {
            Dead();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            Debug.Log("Jump");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Flip();
        }
        
    }

    private void Dead()
    {
        isAlive = false;
        enabled = false;
        spriterenderer.enabled = false;
        Time.timeScale = 0f;
        Debug.Log("게임오버");
    }

    
    public void Flip()
    {
        
     
        if (!isGrounded)
        {
            if (isFlipped)
            {
                var nowpos = transform.position;
                
            }
            else
            {

            }
        }
        else
        {

        }
    }

    public void Jump()
    {
        isGrounded = false;

        if (!spriterenderer.flipY
            && currentJumpCount != 0)
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = gravScale;
            rb.AddForce(Vector2.up * jumpStr, ForceMode2D.Impulse);

            currentJumpCount--;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            currentJumpCount = maxJumpCount;
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {


    }

    private void OnCollisionExit2D(Collision2D collision)
    {


    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Triangle")
        {
            playerHp--;
            Debug.Log($"{playerHp}");
        }
        if (collision.CompareTag("DeadZone"))
        {
            Debug.Log("deadzone");
            Dead();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }

}

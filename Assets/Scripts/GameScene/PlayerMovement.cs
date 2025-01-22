using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CircleCollider2D playercolldier;
    private PlatformMovement platform;

    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;

    public float jumpStr = 5f;
    private int maxJumpCount = 2;
    private int currentJumpCount = 0;

    private float gravPower;

    private bool canJump = true;
    private bool isGrounded = true;
    private bool isAlive = true;

    private bool isFlipped = false;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        playercolldier = GetComponent<CircleCollider2D>();

    }
    private void Start()
    {
        gravPower = rb.gravityScale;
    }

    private void Update()
    {
        if (!isAlive)
        {
            Dead();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Jump();
            Debug.Log("Jump");
        }
       
     
        //if(Physics2D.IsTouching(playercolldier,platformCollider))
        //{

        //}

    }

    private void Dead()
    {
        enabled = false;
    }



    public void Flip()
    {
        
        
  

    }

    public void Jump()
    {
        if (currentJumpCount == 0)
        {
            canJump = false;
        }
        if (currentJumpCount != 0)
        {
            rb.velocity = Vector2.zero;
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
        //isGrounded = false;
        //isCollisonExit = true;

        //var exitobj = collision.collider.gameObject;

        //if (exitobj.CompareTag("Platform"))
        //{
        //    Debug.Log("grave: -1");
        //    rb.gravityScale = -1;
        //}

    }




}

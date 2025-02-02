using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    

    private BoxCollider2D playerBoxCollider;
    private CapsuleCollider2D playerCapsulecolldier;
    private MapMoveMent platform;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;

    public float gravScale;

    public float currentGravScale = 1f;


    public float jumpStr;
    private int maxJumpCount = 2;
    private int currentJumpCount = 0;

    public float playerHp = 500;

    private float gravPower;

    private float NormalScale = 1f;
    private float maxHeight = 5f;

    private bool isGrounded = true;
    public bool isAlive = true;
    private bool isFlipped = false;

   
    public UnityEvent OnSizeChanged;

    //트리거쪽 함수

    public enum CharacterState
    {
        small,
        middle, 
        big
    }

    CharacterState currentState;
    public CharacterState CurrentState
    {
        get { return currentState; }
        set
        {
            switch (value)
            {
                case CharacterState.small:
                    currentState = CharacterState.small;
                    SetPlayerSmall();
                    OnSizeChanged?.Invoke();
                    break;
                case CharacterState.middle:
                    currentState = CharacterState.middle;
                    SetPlayerNomral();
                    OnSizeChanged?.Invoke();
                    break;
                case CharacterState.big:
                    currentState = CharacterState.big;
                    SetPlayerBig();
                    OnSizeChanged?.Invoke();
                    break;
            }
        }
    }


    public float enhancedGravityScale = 0.5f;

    //
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        playerCapsulecolldier = GetComponent<CapsuleCollider2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        CurrentState = CharacterState.middle;
    }
    private void Start()
    {
        gravPower = rb.gravityScale;
        OnSizeChanged?.Invoke();
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
            Small();
        }
        if(transform.position.y > maxHeight)
        {
            Vector3 newpos = transform.position;
            newpos.y = maxHeight;
            transform.position = newpos;
            rb.velocity = Vector2.zero;
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

    private void SetPlayerSmall()
    {
        transform.localScale = new Vector3(1f, 1f, 0f);
        gravScale = 7f;
        jumpStr = 30f;
    }
    private void SetPlayerNomral()
    {
        
        transform.localScale = new Vector3(2f, 2f, 0f);
        gravScale = 6f;
        jumpStr = 20f;
    }
    private void SetPlayerBig()
    {
        transform.localScale = new Vector3(4f, 4f, 0f);
        gravScale = 5f;
        jumpStr = 15f;
    }

    

    public void Small()
    {
        if(CurrentState != CharacterState.small)
        {
            --CurrentState;
        }


        //isSmall = !isSmall;
        //if (isSmall)
        //{
        //    transform.localScale = new Vector3(1f, 1f, 0f);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(2f, 2f, 0f);
        //}

    }
    public void SkillBoom()
    {

    }
    public void Big()
    {
        if(CurrentState != CharacterState.big)
        {
            ++CurrentState;
        }


        //if (isSmall)
        //    return;
        //isBig = !isBig;
        //if (isBig)
        //{
        //    transform.localScale = new Vector3(4f, 4f, 0f);
        //}
        //else
        //{
        //    transform.localScale = new Vector3(2f, 2f, 0f);
        //}
    }

  


    public void Jump()
    {


        isGrounded = false;

        if (transform.localScale.y > 0f
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
        if (collision.tag == "Obsatacle" )
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

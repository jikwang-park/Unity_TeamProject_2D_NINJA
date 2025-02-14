using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    private string id;
    public int playerMaxHp;
    public float attackDamage;
    public float experience;
    public float maxExpGage = 10f;
    public float currentExp = 0f;

    public int currentHp;

    public Animator animator;
    public int levelcount = 1;

    //private Collider2D obstacleCollider;
    private InfinityModeGameManager gameManager;
    public CapsuleCollider2D playerCapsulecolldier;
    private MapMoveMent platform;
    private SpriteRenderer spriterenderer;
    private Rigidbody2D rb;
    
    public float gravScale;

    public float currentGravScale = 1f;


    public float jumpStr;
    private int maxJumpCount = 2;
    private int currentJumpCount = 0;

    private float hpTimer = 2f;
    private float expTimer = 2f;
    private float currentTime = 0f;

    private float gravPower;

    private float NormalScale = 1f;
    private float maxHeight = 5f;
    public float rotationSpeed = 10f;

    private bool isGrounded = true;
    public bool isAlive = true;
    public bool isDamaged = false;
    public bool isInvincible = false;

    private float targetAngle;

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

    //'


    private void Awake()
    {
        isAlive = true;
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<InfinityModeGameManager>();
        rb = GetComponent<Rigidbody2D>();
        playerCapsulecolldier = GetComponent<CapsuleCollider2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        CurrentState = CharacterState.middle;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        gravPower = rb.gravityScale;
        OnSizeChanged?.Invoke();
        //obstacleCollider = GameObject.FindGameObjectWithTag("Obsatacle").GetComponent<Collider2D>();
        
    }

    private void FixedUpdate()
    {
        rb.SetRotation( Mathf.LerpAngle(rb.rotation, targetAngle, Time.fixedDeltaTime * rotationSpeed));
    }
    private void Update()
    {
        //AddHp();
        AddExp();
        if (currentHp > playerMaxHp)
        {
            currentHp = playerMaxHp;
        }
     

        if (currentHp <= 0)
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
        //if (transform.position.y > maxHeight)
        //{
        //    Vector3 newpos = transform.position;
        //    newpos.y = maxHeight;
        //    transform.position = newpos;
        //    rb.velocity = Vector2.zero;
        //}
    }

    public void Init(string id, int playerMaxHp, float playerAttackDamage, float exp)
    {
        this.id = id;
        this.playerMaxHp = playerMaxHp;
        this.attackDamage = playerAttackDamage;
        this.experience = exp;
        currentHp = this.playerMaxHp;
    }


    private void AddExp()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= expTimer)
        {
            currentTime = 0f;
            currentExp += experience;
            gameManager.uiManager.SetExpSlider();
        }

        if (currentExp >= maxExpGage)
        {
            LevelUp();
        }
    }
    private void LevelUp()
    {
        currentExp -= maxExpGage;
        maxExpGage += 10;
        playerMaxHp += 2;
        currentHp += 2;
        levelcount += 1;
        gameManager.uiManager.SetSliderMax();
        gameManager.uiManager.SetExpSilderMax();
        Debug.Log("LEVEL UP");
    }
    
    private void AddHp()
    {
        currentTime += Time.deltaTime;
        if (currentTime > hpTimer)
        {
            currentTime = 0f;
            currentHp += 1;
        }
    }
    private void Dead()
    {
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        animator.SetTrigger("Die");
        isAlive = false;
        enabled = false;
        Time.timeScale = 0f;
        Debug.Log("게임오버");
        gameManager.uiManager.UpdateGameover();
        gameManager.SetGameoverSound();
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
        if (CurrentState != CharacterState.small)
        {
            --CurrentState;
        }
    }

    private void GetExpOnBreakObstacle()
    {
        currentExp += 0.5f;
    }
    public void Big()
    {
        if (CurrentState != CharacterState.big)
        {
            ++CurrentState;
        }
    }
    public void Jump()
    {
     
        isGrounded = false;
        animator.SetBool("Grounded", false);
        if (transform.localScale.y > 0f
            && currentJumpCount != 0)
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = gravScale;
            rb.AddForce(Vector2.up * jumpStr, ForceMode2D.Impulse);
            gameManager.SetJumpSound();


            currentJumpCount--;
        }
    }
    public void TakeDamageOnObs()
    {
        gameManager.SetPlayerHitSound();
        currentHp -= 2;
        if (currentHp < 0)
        { currentHp = 0; }
        gameManager.uiManager.SetSilder();
        gameManager.uiManager.DisplayDamageUI();
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
            currentHp = 0;
        gameManager.uiManager.SetSilder();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 surfaceNormal = collision.contacts[0].normal;
        if (surfaceNormal.y > 0.7f)
        {
            isGrounded = true;
            animator.SetBool("Grounded", true);
            currentJumpCount = maxJumpCount;
        }

      
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 surfaceNormal = collision.contacts[0].normal;
        float slopeAngle = Vector2.Angle(Vector2.up, surfaceNormal);
        if (slopeAngle <= 50)
        {
            ApplyRotationBasedOnSlope(surfaceNormal);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obsatacle")
            && playerCapsulecolldier.IsTouching(collision))
        {

            TakeDamageOnObs();
            GetExpOnBreakObstacle();
            gameManager.uiManager.SetExpSlider();
            Debug.Log($"{currentHp}");
        }
        if (collision.CompareTag("DeadZone")&&playerCapsulecolldier.IsTouching(collision))
        {
            Debug.Log("deadzone");
            Dead();
        }
    }

    private void ApplyRotationBasedOnSlope(Vector2 surfaceNormal)
    {
        targetAngle = Vector2.SignedAngle(Vector2.up, surfaceNormal);
    }

}

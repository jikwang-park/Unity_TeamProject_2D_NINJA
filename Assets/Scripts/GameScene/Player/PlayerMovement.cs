using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum PlayerStatus
    {
        Grounded,
        Jumping,
        Flip,

    }

    private CapsuleCollider2D playercolldier;
    private PlatformMovement platform;

    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;

    private float halfrectheight;

    public float rayDistance = 10f;

    public float jumpStr = 20f;
    public float gravScale = 2f;
    public float addGravStr = 3f;
    private int maxJumpCount = 2;
    private int currentJumpCount = 0;
    

    private float gravPower;
    public float playerHp = 10;


    private bool isGrounded = true;
    public bool isAlive = true;

    RaycastHit2D hitSpot;

    private bool isFlipped = false;

    //트리거쪽 함수
    private bool isCollisionExit = false;

    private bool isUpwardCollsion = false;
    private bool isDownwardCollsion = false;

   

    
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
        halfrectheight = spriterenderer.size.y / 2;
        gravPower = rb.gravityScale;
    }



    private void Update()
    {
        if(playerHp <= 0)
        {
            isAlive = false;
        }

        if (!isAlive)
        {
            Dead();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Jump();
            Debug.Log("Jump");
        }

       
      

    }



    private void Dead()
    {
        isAlive = false;
        enabled = false;
        spriterenderer.enabled = false;
        GamOver();
    }



    public void Filp()
    {
        

        isFlipped = !isFlipped;
        if(isGrounded)
        {
            if (isFlipped)
            {
                spriterenderer.flipY = true;

            }
            else
            {
                spriterenderer.flipY = false;
            }
        }
     
        //playercolldier.isTrigger = true;
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

    public void GamOver()
    {
        Time.timeScale = 0f;
        Debug.Log("게임오버");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
   
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Triangle")
        {
            playerHp--;
            Debug.Log($"{playerHp}");
        }
        if(collision.CompareTag("DeadZone"))
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

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CapsuleCollider2D playercolldier;
    private PlatformMovement platform;

    private Rigidbody2D rb;
    private SpriteRenderer spriterenderer;

    private float halfrectheight;

    public float rayDistance = 10f;

    public float jumpStr = 5f;
    public float addGravStr = 3f;
    private int maxJumpCount = 2;
    private int currentJumpCount = 0;

    private float gravPower;


    private bool isGrounded = true;
    private bool isAlive = true;

    RaycastHit2D hitSpot;

    private bool isFlipped = false;

    //트리거쪽 함수
    private bool isCollisionExit = false;

    private bool isUpwardCollsion = false;
    private bool isDownwardCollsion = false;
    private int flipCount = 0;
   
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
        if (!isAlive)
        {
            Dead();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Jump();
            Debug.Log("Jump");
        }
        //Vector2 rayStartPos = transform.position;
        //Vector2 rayDirection = transform.up;


        //LayerMask groundLayerMask = LayerMask.GetMask("Ground");

        //hitSpot = Physics2D.Raycast(
        //   rayStartPos, rayDirection, rayDistance, groundLayerMask);

        //if (hitSpot.collider != null)
        //{
        //    Vector2 hitpoint = new Vector2(hitSpot.point.x, hitSpot.point.y);
        //    transform.position = hitpoint;
        //}


    }



    private void Dead()
    {
        enabled = false;
    }



    public void Filp()
    {
        isFlipped = !isFlipped;
        if(isFlipped)
        {
            spriterenderer.flipY = true;
            
        }
        else
        {
            spriterenderer.flipY = false;
        }
        //playercolldier.isTrigger = true;
    }

    public void Jump()
    {
        
       
        if (!spriterenderer.flipY
            &&currentJumpCount != 0)
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
        //if (collision.collider.tag == "Platform")
        //{
        //    float ty = collision.collider.transform.position.y;
        //    if (transform.position.y < ty)
        //    {
        //        Vector3 fixedPos = transform.position;
        //        fixedPos.y = ty;
        //        transform.position = fixedPos;
        //    }
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.collider.tag == "Platform")
        //{
        //    isFlipped = false;

         

        //}
    }
}

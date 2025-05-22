using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool betterJump= false;
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))  
        {
            rb2D.linearVelocity= new Vector2(+runSpeed,rb2D.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if(Input.GetKey("a") || Input.GetKey("left")) 
        {
            rb2D.linearVelocity= new Vector2(-runSpeed,rb2D.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else 
        {
            rb2D.linearVelocity= new Vector2(0,rb2D.linearVelocity.y);
            animator.SetBool("Run", false);
        }
        if(Input.GetKey("w") && CheckGround.isGrounded)
        {
            rb2D.linearVelocity= new Vector2(rb2D.linearVelocity.x, jumpSpeed);
            animator.SetBool("Run", false);
        }

        if(CheckGround.isGrounded==false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run",false);
        }
        if(CheckGround.isGrounded==true)
        {
            animator.SetBool("Jump", false);
            
        }
        if(betterJump)
        {
            if(rb2D.linearVelocity.y<0)
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
             if(rb2D.linearVelocity.y>0 && !Input.GetKey("w"))
            {
                rb2D.linearVelocity += Vector2.up*Physics2D.gravity.y* (lowJumpMultiplier) * Time.deltaTime;
            }
        }

    }
}

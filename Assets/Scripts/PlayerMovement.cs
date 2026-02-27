using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    

    [SerializeField] private LayerMask JumpGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int maxJumps = 2;
    private int _jumpsLeft;
  
   
    private enum MovementState { idle, run, jump, falling, attack }

    [SerializeField] private AudioSource jumpSFX;
    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    
        _jumpsLeft = maxJumps;
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if ( WhetherGrounded() && rb.velocity.y <= 0)
        {
            
            _jumpsLeft = maxJumps;

        }



        if (Input.GetButtonDown("Jump") && _jumpsLeft > 0)
        {
            jumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            _jumpsLeft -= 1;
        }

        UpdateAnimationState();


    }



    private void UpdateAnimationState()
    {

        MovementState state;

        if (dirX > 0)
        {
            
            state = MovementState.run;
            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
        else if (dirX < 0)
        {
          
            state = MovementState.run;
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.01f)
        {
            state = MovementState.jump;

        }
        else if (rb.velocity.y < -0.01f)
        {

            state = MovementState.falling;
        }
        

        anim.SetInteger("State", (int)state);
    }



    private bool WhetherGrounded()

    { 
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, JumpGround);
      
    }

    public bool canAttack()
    {
        return Input.GetAxisRaw("Horizontal") == 0 && WhetherGrounded();
    }


    public void endAttack()
    {
        anim.SetBool("isAttacking", false) ;
    }

    
}

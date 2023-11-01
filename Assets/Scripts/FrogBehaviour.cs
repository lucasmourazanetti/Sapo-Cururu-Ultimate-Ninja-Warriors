using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MovementState { Idle, Run, Jump, Fall}

    [SerializeField] private AudioSource jumpSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         sprite = GetComponent<SpriteRenderer>();
         coll = GetComponent<BoxCollider2D>();
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if(dirX > 0f)
        {
            state = MovementState.Run;
            sprite.flipX = false;
            
        }

        else if (dirX < 0f)
        {
            state = MovementState.Run;
            sprite.flipX = true;
        }

        else
        {
            state = MovementState.Idle;

        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.Jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.Fall;
        }


        anim.SetInteger("state", (int)state);
        
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}

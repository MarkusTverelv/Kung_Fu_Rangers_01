using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator anim;
    private string currentAnimation;

    public float gravity;
    public Vector2 velocity;

    public float maxXVelocity = 100;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float distance = 0;

    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;

    private float size;
    public SpriteRenderer spriteRenderer;
    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float maxMaxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshold = 1;

    public LayerMask groundLayerMask;

    void Start()
    {
        size = spriteRenderer.bounds.size.y * transform.localScale.y;
    }

    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);
        Debug.Log(groundDistance);

        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                holdJumpTimer = 0;
                ChangeAnimation("Player_Jump");
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
            ChangeAnimation("Player_Fall");
        }

        if (isGrounded)
        {
            ChangeAnimation("Player_Run");
        }
    }

    public void ChangeAnimation(string newAnimation)
    {
        if (newAnimation != currentAnimation)
        {
            anim.Play(newAnimation);
            currentAnimation = newAnimation;
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (pos.y != groundHeight)
        {
            isGrounded = false;
        }

        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump = false;
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime;
            if (!isHoldingJump && !isGrounded)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }


            Vector2 rayOrigin = new Vector2(pos.x + 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;

            float rayDistance = velocity.y * Time.fixedDeltaTime;

            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, groundLayerMask);

            if (hit2D.collider != null)
            {
                Ground ground = hit2D.collider.GetComponent<Ground>();
                if (ground != null)
                {
                    if (pos.y >= groundHeight)
                    {
                        velocity.y = 0;
                        isGrounded = true;
                    }
                }
            }

            Debug.DrawRay(rayOrigin, rayDirection * rayDirection, Color.red);
        }

        if (transform.position.y <= -10)
        {
            SceneManager.LoadScene("GameOver");
        }

        distance += velocity.x * Time.fixedDeltaTime;

        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            maxHoldJumpTime = maxMaxHoldJumpTime * velocityRatio;

            velocity.x += acceleration * Time.fixedDeltaTime;
            if (velocity.x >= maxXVelocity)
            {
                velocity.x = maxXVelocity;
            }
        }
        transform.position = pos;
    }
}

using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float jump = 10;
    private bool canJump = true;
    public float maxspeed = 5;
    public float stoppingForce = 5;
    public float DashForceAmount = 10;
    private bool canDash = true;

    private float XPosLastFrame;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandlePlayerXMovement();
        MaxSpeedLimit();
        FlipCharacterX();
        //transform.position += new Vector3(direction.x, direction.y, 0) * Time.deltaTime * speed;
    }

    private void HandlePlayerXMovement()
    {
        if (direction.x != 0)
        {
            rigidbody2D.AddForce(new Vector2(direction.x, 0) * speed);
        }
        else if (rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
        if (direction.x != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void FlipCharacterX()
    {
        if (transform.position.x > XPosLastFrame)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < XPosLastFrame)
        {
            spriteRenderer.flipX = true;
        }
        XPosLastFrame = transform.position.x;
    }

    private void MaxSpeedLimit()
    {
        if (!canDash)
        {
            return;
        }
        if (rigidbody2D.linearVelocityX >= maxspeed)
        {
            //Debug.Log("exceding nax speed");
            rigidbody2D.linearVelocityX = maxspeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxspeed)
        {
            rigidbody2D.linearVelocityX = -maxspeed;
        }
    }

    private void OnMove(InputValue value)
    {
        //Debug.Log("Move");
        //Debug.Log(value.Get<Vector2>());
        direction = value.Get<Vector2>();
    }
    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            canJump = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
    private void OnDash()
    {
        //Debug.Log("dash");
        if (canDash)
        {
            if (direction.x != 0)
            {
                rigidbody2D.AddForce(new Vector2(direction.x * DashForceAmount, 0), ForceMode2D.Impulse);
            }
            else
            {
                rigidbody2D.AddForce(new Vector2(DashForceAmount, 0), ForceMode2D.Impulse);

            }
            canDash = false;
            StartCoroutine(ResetDash(1));
        }
    }
    IEnumerator ResetDash(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }
}

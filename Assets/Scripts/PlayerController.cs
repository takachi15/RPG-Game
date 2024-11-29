using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 MovementInput;
    public Rigidbody2D rb;
    public Animator animator;
    public List<RaycastHit2D> castcollsions = new List<RaycastHit2D>();
    public float speed = 1f;
    public float collsionsoffset = 0.005f;
    public ContactFilter2D contactFilter;
    SpriteRenderer spriteRenderer;
    bool success;
    bool canMove;
    // Thêm tham chiếu đến SwordAttack
    public SwordAttack swordAttack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Gán SwordAttack
        swordAttack = GetComponentInChildren<SwordAttack>();
    }
    void OnMove(InputValue MovementValue)
    {
        MovementInput = MovementValue.Get<Vector2>();
    }
    private void FixedUpdate()
    {
        Debug.Log(MovementInput);
        ConditonalMove(MovementInput);
    }

    void ConditonalMove(Vector2 MovementInput)
    {
        if (MovementInput != Vector2.zero)
        {
            success = TryMove(MovementInput);
            if (!success)
            {
                success = TryMove(new Vector2(MovementInput.x, 0));

                if (!success)
                {
                    success = TryMove(new Vector2(0, MovementInput.y));
                }
            }
            animator.SetBool("IsMoving", success);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        print("IsMoving:" + animator.GetBool("IsMoving"));
        //set direction sprite to movement direction
        if (MovementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (MovementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    protected bool TryMove(Vector2 MovementInput)
    {
        // if movementinput is not 0,try to move
        if (MovementInput != Vector2.zero)
        {
            int Count = rb.Cast(MovementInput,
                contactFilter,
                castcollsions,
                speed * Time.deltaTime + collsionsoffset);
            if (Count == 0)
            {
                rb.MovePosition(rb.position + MovementInput * speed * Time.fixedDeltaTime);
                return true;
            }

            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    public void SwordAttacks()
    {
        if (spriteRenderer.flipX == true)
        {
            swordAttack.Attack(SwordAttack.AttackDirection.Left);
        }
        else
        {
           swordAttack.Attack(SwordAttack.AttackDirection.Right);
        }
    }
    

    public void PerformanceSwordAttack()
    {
        LockMovement();

    }
    public void LockMovement()
    {
        canMove = false;
    }
    public void UnLockMovement()
    {
        canMove = true;
    }
    void OnFire()
    {
        animator.SetTrigger("SwordAttack");

        // Xác định hướng tấn công dựa trên hướng di chuyển
        
    }
}

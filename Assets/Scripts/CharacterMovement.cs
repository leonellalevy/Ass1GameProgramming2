using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Vector3 playerVelocity;
    public bool isOnGround = false;

    public float walkSpeed = 5;
    public float runSpeed = 8;
    public float jumpHeight = 2;
    public int maxJumpCount = 1;
    public float gravity = -9.18f;
    public bool isGrounded;

    private CharacterController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    public void Update()
    {
        if (animator.applyRootMotion == false)
        {
            ProcessMovement();
        }
        ProcessGravity();

    }

    public void LateUpdate()
    {
        UpdateAnimator();
    }

    void DisableRootMotion()
    {
        animator.applyRootMotion = false;
    }

    void UpdateAnimator()
    {
        isOnGround = controller.isGrounded;
        Vector3 characterXandZMotion = new Vector3(playerVelocity.x, 0.0f, playerVelocity.z);
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.0f || Mathf.Abs(Input.GetAxis("Vertical")) > 0.0f)
        {
            if (Input.GetButton("Fire3"))// Left shift
            {
                animator.SetFloat("Speed", 1.0f);
            }
            else
            {
                animator.SetFloat("Speed", 0.5f);
            }
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }

    }
    void ProcessMovement()
    {
        float speed = GetMovementSpeed();
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        controller.Move(move * Time.deltaTime * GetMovementSpeed());
    }

    
    public void ProcessGravity()
    {
        // Since there is no physics applied on character controller we have this applies to reapply gravity
        
        if (isGrounded  )
        {
            if (playerVelocity.y < 0.0f) // we want to make sure the players stays grounded when on the ground
            {
                playerVelocity.y = -1.0f;
            }

            if (Input.GetButtonDown("Jump")) // Code to jump
            {
                playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravity);
                animator.SetTrigger("JumpTrigger");
            }
        }
        else // if not grounded
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);
        isGrounded = controller.isGrounded;
        
    }
    

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}
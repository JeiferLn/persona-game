using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    [SerializeField] private float moveSpeed = 5f;

    private float Horizontal;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0)
        {
            Animator.SetBool("isIdleLeft", true);
            Animator.SetBool("isIdleRight", false);
        }
        else if (Horizontal > 0)
        {
            Animator.SetBool("isIdleLeft", false);
            Animator.SetBool("isIdleRight", true);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(Horizontal * moveSpeed, Rigidbody2D.linearVelocity.y);
        if (Horizontal > 0)
        {
            Animator.SetBool("isWalkingRight", true);
            Animator.SetBool("isWalkingLeft", false);
        }
        else if (Horizontal < 0)
        {
            Animator.SetBool("isWalkingRight", false);
            Animator.SetBool("isWalkingLeft", true);
        }
        else
        {
            Animator.SetBool("isWalkingRight", false);
            Animator.SetBool("isWalkingLeft", false);
        }
    }
}

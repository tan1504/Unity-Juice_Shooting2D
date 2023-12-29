using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;
    public GameObject character;

    void Start()
    {
        animator = character.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //moveDirection.x = Input.GetAxisRaw("Horizontal");
        //moveDirection.y = Input.GetAxisRaw("Vertical");
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
        //rb.MovePosition(rb.position + moveDirection.normalized * moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}

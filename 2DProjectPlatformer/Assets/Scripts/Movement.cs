using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private int Lives = 3;
    private float speed = 2.0f;
    private float jumpForce = 4f;
    bool isGrounded = true;
    public Rigidbody2D PlayerRigibody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        PlayerRigibody = GetComponentInChildren<Rigidbody2D>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        //CheckGround();
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            animator.SetInteger("State", 1);
            Move();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetInteger("State", 2);
            Jump();
        }
        if (!Input.anyKey)
        {
            animator.SetInteger("State", 0);
        }
    }

    void Move()
    {
        Vector3 tempVector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempVector, speed * Time.deltaTime);
        if (tempVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    void Jump()
    {
        if (isGrounded)
            PlayerRigibody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}

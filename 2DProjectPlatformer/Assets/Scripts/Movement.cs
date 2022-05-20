using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Lives = 3;
    public float speed = 2.0f;
    public float jumpForce = 0.5f;
    bool OnGround;
    public Rigidbody2D PlayerRigibody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

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
        CheckGround();
    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            animator.SetInteger("State", 1);
            Move();
        }
        if (OnGround && Input.GetButton("Jump"))
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
        PlayerRigibody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        OnGround = colliders.Length > 1;
    }
}

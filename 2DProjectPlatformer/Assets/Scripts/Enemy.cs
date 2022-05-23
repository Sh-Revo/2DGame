using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public float range = 3f;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    float startingX;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * direction);
        if (transform.position.x < startingX || transform.position.x > startingX + range)
        {
            direction *= -1;
        }
        if (direction == -1)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

}

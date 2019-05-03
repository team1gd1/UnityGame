using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.UIElements.GraphView;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 position;
    public Vector2 jump;
    public float speed;
    public Animator animator;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        position = new Vector2(0.0f, 0.0f);
        jump = new Vector2(0.0f, 0.0f);
        position.x = 1.0f;
        jump.y = 5.0f;
        isAttacking = false;
    }

    void FixedUpdate()
    {
        playerMovement();
        playerAttack();
    }

    void playerMovement()
    {
        if (Input.GetKey("d"))
        {
            //animator.SetFloat("speed", 1.0f);
            rb.AddForce(position * speed);
        }
        else if (Input.GetKey("a"))
        {
            //animator.SetFloat("speed", 1.0f);
            rb.AddForce((-1 * position) * speed);
        }
    }

    void playerAttack()
    {
        if (Input.GetKeyDown("f") && isAttacking == false)
        {
            isAttacking = true;
            //animator.SetBool("isAttacking", isAttacking);
            isAttacking = false;
        }

    }

}
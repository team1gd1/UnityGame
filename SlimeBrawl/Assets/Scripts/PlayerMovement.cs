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
    private bool isLeft = false;
    private bool isjump;

    public int JumpHeight;

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
            animator.SetFloat("Walk", 1.0f);
            //rb.AddForce(position * speed);
            if (isLeft == true)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                isLeft = false;

            }
            transform.Translate(position * speed * Time.deltaTime);
        }
        else if (Input.GetKey("a"))
        {
            animator.SetFloat("Walk", 1.0f);
            //rb.AddForce((-1 * position) * speed);
            if (isLeft == false)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                isLeft = true;
            }
            transform.Translate(position * speed * Time.deltaTime);

        }
        if (isjump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // JumpVoice.PlayOneShot(JumpBGM);
                rb.velocity = (new Vector2(0, JumpHeight));
               // Jumplimit = 1.1f * JumpHeight / 5;
                isjump = true;
            }
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

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.tag == "musuh")
        //{
        //    anim.SetTrigger("die");
        //    DestroyedVoice.PlayOneShot(DestroyedBGM);
        //    Instantiate(PlayerDummy, transform.position, transform.rotation);
        //    RestartButton.SetActive(true);
        //    Time.timeScale = 0; ;
        if (col.gameObject.tag == "Ground")
        {
            isjump = false;
        }
        //if (col.gameObject.tag == "Limit")
        //{
        //    anim.SetTrigger("Die");
        //    playerbody.velocity = (new Vector2(0, JumpHeight));
        //    //DestroyedVoice.PlayOneShot(DestroyedBGM);
        //    // Instantiate(PlayerDummy, transform.position, transform.rotation);
        //    // yield return new WaitForSeconds(1);
        //    // RestartButton.SetActive(true);
        //    //Time.timeScale = 0; 
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //}

}
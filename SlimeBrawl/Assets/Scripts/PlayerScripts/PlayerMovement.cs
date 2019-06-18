/***********************
  Bachelor of Software Engineering
  Media Design School
  Auckland
  New Zealand

  (c) 2018 Media Design School

  File Name   :   PlayerMovements.cs
  Description :   contain fuctions that manage player character's size changes according to it's health changes
  Author      :   Sakyawira Nanda Ruslim, Thomas Heeley, Jacob van Asch
  Mail        :   Sakyawira.Rus8080@mediadesign.school.nz, Jacob.van8310@mediadesign.school.nz, Thomas.Hee8396@mediadesign.school.nz
********************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Public
    public GameObject PlayerDummy;
    public GameObject RestartButton;
    public GameObject PlayerParent;
    public GameObject PlayerCheck;
    public GameObject PlayerCheck2;

    public AudioClip CheckSE;
    public AudioClip CoinBGM;
    public AudioClip TextBGM;
    public AudioClip DestroyedBGM;
    public AudioClip KillBGM;
    public AudioClip JumpBGM;

    public Text ScoreText;

    public bool isPlayer2;

    public float speed;
    public float climbSpeed;
    public float JumpHeight = 0;

    public int score;
   
    //Private
    private Rigidbody2D rb;

    private Animator animator;

    private AudioSource CoinVoice;
    private AudioSource JumpVoice;
    private AudioSource CheckVoice;
    private AudioSource TextVoice;
    private AudioSource DestroyedVoice;
    private AudioSource KillVoice;

    private float climbVelocity;
    private float gravityStore;
    //private float Jumplimit = 0;

    private bool isleft = true;
    private bool isjump = false;
   // private bool onLadder = false;

    // Use this for initialization
    void Start()
    {

        //PlayerCheck = GameObject.FindGameObjectWithTag("Checkpoint");
        //PlayerCheck2 = GameObject.FindGameObjectWithTag("Checkpoint2");
        //CheckpointPosition();
        rb = GetComponent<Rigidbody2D>();
        gravityStore = rb.gravityScale;
        animator = GetComponent<Animator>();
        //  JumpVoice = GetComponent<AudioSource>();
        //TextVoice = GetComponent<AudioSource>();
        // CoinVoice = GetComponent<AudioSource>();
        // DestroyedVoice = GetComponent<AudioSource>();
        // KillVoice = GetComponent<AudioSource>();
        // CheckVoice = GetComponent<AudioSource>();

       // onLadder = false;
    }

    // Update is called once per frame
    void Update()
    {
      //  animator.SetFloat("Climb", 0f);
       // animator.SetFloat("Walk", 0f);
        PlayerMovements();
    }


    void PlayerMovements()
    {
        if (Input.GetKey(KeyCode.RightArrow) && isPlayer2 || Input.GetKey(KeyCode.D) && !isPlayer2)
        {
            if (isleft == true)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                isleft = false; 
            }
            animator.SetFloat("Walk", 0.2f);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && isPlayer2 || Input.GetKey(KeyCode.A)  && !isPlayer2)
        {
            if (isleft == false)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                isleft = true;
            }
            animator.SetFloat("Walk", 0.2f);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        //On The Ground
        if (isjump == false)
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && isPlayer2 || Input.GetKey(KeyCode.Space)  && !isPlayer2)
            {
                //JumpVoice.PlayOneShot(JumpBGM);
                rb.velocity = (new Vector2(0, JumpHeight));
                //Jumplimit = 1.0f;
                isjump = true;
                animator.SetBool("isJumping", isjump);
            }

        }
        //Mid-Air
        else if (isjump == true)
        {
            if (rb.velocity.y != 0)
            {
                rb.gravityScale = rb.gravityScale + 0.1f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isjump = false;
            animator.SetBool("isJumping", isjump);
            rb.gravityScale = gravityStore;
            //Jumplimit = 0;
        }
        if (col.gameObject.tag == "Limit")
        { 
            animator.SetTrigger("Die");
            rb.velocity = (new Vector2(0, JumpHeight));
            //DestroyedVoice.PlayOneShot(DestroyedBGM);
            // Instantiate(PlayerDummy, transform.position, transform.rotation);
            // yield return new WaitForSeconds(1);
            // RestartButton.SetActive(true);
            //Time.timeScale = 0; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}








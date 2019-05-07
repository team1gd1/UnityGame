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
    private Rigidbody2D playerbody;

    private Animator anim;

    private AudioSource CoinVoice;
    private AudioSource JumpVoice;
    private AudioSource CheckVoice;
    private AudioSource TextVoice;
    private AudioSource DestroyedVoice;
    private AudioSource KillVoice;

    private float climbVelocity;
    private float gravityStore;
    private float Jumplimit = 0;

    private int scoreminus;

    private bool isleft = true;
    private bool isjump = false;
    private bool onLadder = false;

  


    // Use this for initialization
    void Start()
    {

        //PlayerCheck = GameObject.FindGameObjectWithTag("Checkpoint");
        //PlayerCheck2 = GameObject.FindGameObjectWithTag("Checkpoint2");
        //CheckpointPosition();
        playerbody = GetComponent<Rigidbody2D>();
        gravityStore = playerbody.gravityScale;
        anim = GetComponent<Animator>();
        //  JumpVoice = GetComponent<AudioSource>();
        //TextVoice = GetComponent<AudioSource>();
        // CoinVoice = GetComponent<AudioSource>();
        //   DestroyedVoice = GetComponent<AudioSource>();
        //  KillVoice = GetComponent<AudioSource>();
        //  CheckVoice = GetComponent<AudioSource>();

        onLadder = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Climb", 0f);
        anim.SetFloat("Walk", 0f);

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
            anim.SetFloat("Walk", 0.2f);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && isPlayer2 || Input.GetKey(KeyCode.A)  && !isPlayer2)
        {
            if (isleft == false)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                isleft = true;
            }
            anim.SetFloat("Walk", 0.2f);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        //On The Ground
        if (isjump == false)
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && isPlayer2 || Input.GetKey(KeyCode.Space)  && !isPlayer2)
            {
                // JumpVoice.PlayOneShot(JumpBGM);
                playerbody.velocity = (new Vector2(0, JumpHeight));
                Jumplimit = 1.0f;
                isjump = true;
            }

        }
        //Mid-Air
        else if (isjump == true)
        {
            if (playerbody.velocity.y != 0)
            {
                playerbody.gravityScale = playerbody.gravityScale + 0.1f;
            }
        }
    }
   

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isjump = false;
            playerbody.gravityScale = gravityStore;
            Jumplimit = 0;
        }
        if (col.gameObject.tag == "Limit")
        {
            anim.SetTrigger("Die");
            playerbody.velocity = (new Vector2(0, JumpHeight));
            //DestroyedVoice.PlayOneShot(DestroyedBGM);
            // Instantiate(PlayerDummy, transform.position, transform.rotation);
            // yield return new WaitForSeconds(1);
            // RestartButton.SetActive(true);
            //Time.timeScale = 0; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}








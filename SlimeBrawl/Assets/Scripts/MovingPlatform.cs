using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public int PlatSpeed;
    public bool isRightPlat = true;
    public bool isVertical = false;

    Rigidbody2D Plat;
    // Use this for initialization
    void Start()
    {
        Plat = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlat();
    }
    void MovementPlat()
    {
        if (isVertical == true)
        {
            if (isRightPlat == true)
            {
                Plat.velocity = new Vector2(0, PlatSpeed);
                //transform.Translate (Vector2.up * PlatSpeed * Time.deltaTime);
            }
            else if (isRightPlat == false)
            {
                Plat.velocity = new Vector2(0, -PlatSpeed);
                //transform.Translate (Vector2.down * PlatSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (isRightPlat == true)
            {
                Plat.velocity = new Vector2(PlatSpeed, 0);
                //transform.Translate (Vector2.up * PlatSpeed * Time.deltaTime);
            }
            else if (isRightPlat == false)
            {
                Plat.velocity = new Vector2(- PlatSpeed , 0);
                //transform.Translate (Vector2.down * PlatSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PlatSpot")
        {
            if (isRightPlat == true)
            {
                isRightPlat = false;
            }
            else if (isRightPlat == false)
            {
                isRightPlat = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Trap")
        {
            if (isRightPlat == true)
            {
                PlatSpeed += 5;
                isRightPlat = false;
                PlatSpeed += 5;
            }
            else if (isRightPlat == false)
            {
                PlatSpeed -= 5;
                isRightPlat = true;
                PlatSpeed -= 5;
            }
        }
    }
}
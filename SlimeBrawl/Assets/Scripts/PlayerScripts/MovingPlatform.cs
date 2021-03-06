﻿/***********************
  Bachelor of Software Engineering
  Media Design School
  Auckland
  New Zealand

  (c) 2018 Media Design School

  File Name   :   MovingPlatform.cs
  Description :   fucntions that manage moving platforms in the levels
  Author      :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira.Rus8080@mediadesign.school.nz
********************/

using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    public int PlatSpeed = 2;
    public bool isRightPlat = true;
    public bool isVertical = false;
    public Vector3 startingPosition;

    public float maxMovement = 1.3f;

    Rigidbody2D Plat;
    // Use this for initialization
    void Start()
    {
        Plat = GetComponent<Rigidbody2D>();
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlat();
        ChangeDirection();
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

    void ChangeDirection()
    {
        if (gameObject.transform.localPosition.y > startingPosition.y + maxMovement) //|| gameObject.transform.localPosition.x > startingPosition.x + 50)
        {
            isRightPlat = false;
        }
        if (gameObject.transform.localPosition.y < startingPosition.y - maxMovement) //|| gameObject.transform.localPosition.x > startingPosition.x - 50)
        {
            isRightPlat = true;
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
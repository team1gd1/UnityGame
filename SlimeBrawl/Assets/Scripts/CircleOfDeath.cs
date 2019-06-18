/***********************
  Bachelor of Software Engineering
  Media Design School
  Auckland
  New Zealand

  (c) 2018 Media Design School

  File Name   :   CircleOfDeath.h
  Description :   contains function to create a shrinking circle that does damage to the player
  Author      :   Sakyawira Nanda Ruslim
  Mail        :   Sakyawira.Rus8080@mediadesign.school.nz
********************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleOfDeath : MonoBehaviour
{
    Vector3 startingScale;
 
    void Start()
    {
        startingScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x <= 1f * startingScale.x && transform.localScale.x >= 0.999f * startingScale.x)
        {
            transform.localScale -= new Vector3(0.0001f * Time.deltaTime, 0.0001f * Time.deltaTime, 0);
        }
        else if (transform.localScale.x <= 0.8f * startingScale.x && transform.localScale.x >= 0.799f * startingScale.x)
        {
            transform.localScale -= new Vector3(0.0001f * Time.deltaTime, 0.0001f * Time.deltaTime, 0);
        }
        else if (transform.localScale.x <= 0.5f * startingScale.x && transform.localScale.x >= 0.499f * startingScale.x)
        {
            transform.localScale -= new Vector3(0.0001f * Time.deltaTime, 0.0001f * Time.deltaTime, 0);
        }
        else if (transform.localScale.x <= 0.2f * startingScale.x && transform.localScale.x >= 0.199f * startingScale.x)
        {
            transform.localScale -= new Vector3(0.0001f * Time.deltaTime, 0.0001f * Time.deltaTime, 0);
        }
        else if (transform.localScale.x <= 0.0822f * startingScale.x)
        {

        }
        else
        {
            transform.localScale -= new Vector3(0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0);
        }
    }

   
}

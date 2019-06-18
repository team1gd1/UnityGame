/***********************
  Bachelor of Software Engineering
  Media Design School
  Auckland
  New Zealand

  (c) 2018 Media Design School

  File Name   :   Attack.cs
  Description :   manage attack system of the players
  Author      :   Thomas Heeley
  Mail        :   Thomas.Hee8396@mediadesign.school.nz
********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator Anim;
    private bool isAttacking;
    public bool isPlayer2;
    //private bool isIdle;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerAttack();
        //EndAttack();
       // Anim.SetBool("isIdle", isIdle);
    }

    void playerAttack()
    {
        if (Input.GetKeyDown("f") && isAttacking == false && isPlayer2 != true)
        {
            isAttacking = true;
            Anim.SetBool("isAttacking", isAttacking);
            
        }

        if (Input.GetKeyDown("m") && isAttacking == false && isPlayer2 == true)
        {
            isAttacking = true;
            Anim.SetBool("isAttacking", isAttacking);
        }
    }

    void EndAttack()
    {
        isAttacking = false;
        Anim.SetBool("isAttacking", isAttacking);
    }
}

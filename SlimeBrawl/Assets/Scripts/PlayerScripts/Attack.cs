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
    public Transform firePoint;
    private Animator Anim;
    private bool isAttacking;
    public bool isPlayer2;
    public GameObject buletPrefab;
    public playerManager manager;

    //private bool isIdle;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        manager = GetComponent<playerManager>();

        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerAttack();
    }

    void playerAttack()
    {
        if (Input.GetKeyDown("f") && isAttacking == false && isPlayer2 != true)
        {
            isAttacking = true;
            Anim.SetBool("isAttacking", isAttacking);

            if (manager.m_rayGunBool == true)
            {
                Instantiate(buletPrefab, firePoint.position, firePoint.rotation);
            }

        }

        if (Input.GetKeyDown("m") && isAttacking == false && isPlayer2 == true)
        {
            isAttacking = true;

            Anim.SetBool("isAttacking", isAttacking);

            if (manager.m_rayGunBool == true)
            {
                Instantiate(buletPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }

    void EndAttack()
    {
        isAttacking = false;
        Anim.SetBool("isAttacking", isAttacking);
    }
}

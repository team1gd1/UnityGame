﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator Anim;
    private bool isAttacking;
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
       // Anim.SetBool("isIdle", isIdle);
    }

    void playerAttack()
    {
        if (Input.GetKeyDown("f") && isAttacking == false)
        {
            isAttacking = true;
            Anim.SetBool("isAttacking", isAttacking);
        }
    }
}

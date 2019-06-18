/***********************
  Bachelor of Software Engineering
  Media Design School
  Auckland
  New Zealand

  (c) 2018 Media Design School

  File Name   :   playerManager.cs
  Description :   manage the changes of player sprites 
  Author      :   Thomas Heeley
  Mail        :   Thomas.Hee8396@mediadesign.school.nz
********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public GameObject player;
    public GameObject weapon;
    public SpriteRenderer m_spriteRenderer;
    public Sprite axeSprite;
    public Sprite rayGunSprite;
    public Animator m_anim;
    public bool m_axeBool;
    public bool m_rayGunBool;

    // Start is called before the first frame update
    void Start()
    {
        m_axeBool = false;
        m_rayGunBool = false;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Axe")
        {
            weapon = collision.gameObject;
            collision.gameObject.SetActive(false);
            m_axeBool = true;
            m_rayGunBool = false;
        }

        if (collision.gameObject.tag == "rayGun")
        {
            weapon = collision.gameObject;
            collision.gameObject.SetActive(false);
            m_axeBool = false;
            m_rayGunBool = true;
        }
    }

    void UpdateSprite()
    {
        if (m_axeBool == true)
        {
            m_spriteRenderer.sprite = axeSprite;
            m_anim.SetBool("isAxe", true);
            m_anim.SetBool("isGun", false);
        }

        if (m_rayGunBool == true)
        {
            m_spriteRenderer.sprite = rayGunSprite;
            m_anim.SetBool("isGun", true);
            m_anim.SetBool("isAxe", false);
        }

    }

}

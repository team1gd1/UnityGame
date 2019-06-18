/***********************
  Bachelor of Software Engineering
  Media Design School
  Auckland
  New Zealand

  (c) 2018 Media Design School

  File Name   :   PlayerGrow.cs
  Description :   contain fuctions that manage player character's size changes according to it's health changes
  Author      :   Sakyawira Nanda Ruslim, Jacob van Asch
  Mail        :   Sakyawira.Rus8080@mediadesign.school.nz, Jacob.van8310@mediadesign.school.nz
********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerGrow : MonoBehaviour
{
    Vector3 playerScale;
    public Slider playerSize;
    public float startingSize = 100;
    public float currentSize;
    public GameObject player;
    public float pixelsPerUnit;


    // Start is called before the first frame update
    void Start()
    {
        currentSize = startingSize;
        player = gameObject;
        currentSize = player.gameObject.GetComponent<PlayerHealth>().currentHealth;
       // player.transform.localScale = new Vector3(currentSize, currentSize);
    }

    // Update is called once per frame
    void Update()
    {
       
       grow();
    }

    void grow()
    {
      currentSize = player.gameObject.GetComponent<PlayerHealth>().currentHealth;
      if (player.transform.localScale.x >= currentSize/50)
        {
            player.transform.localScale = player.transform.localScale - new Vector3(currentSize/100 * Time.deltaTime, currentSize/100 * Time.deltaTime);
        }
     
        
    }
}

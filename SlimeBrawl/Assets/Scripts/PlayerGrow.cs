﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGrow : MonoBehaviour
{

    public Slider playerSize;
    public float startingSize = 100;
    public float currentSize;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentSize = startingSize;
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        currentSize = player.gameObject.GetComponent<PlayerHealth>().currentHealth;
        
    }
}
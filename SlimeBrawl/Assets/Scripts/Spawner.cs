/***********************
  Bachelor of Software Engineering
  Media Design School
  Auckland
  New Zealand

  (c) 2018 Media Design School

  File Name   :   Spawn.cs
  Description :   manage weapons spawning system
  Author      :   Thomas Heeley
  Mail        :   Thomas.Hee8396@mediadesign.school.nz
********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rayGun;
    public GameObject Axe;
    private int rayGunMax = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        weaponSpawner();
    }

    void weaponSpawner()
    {
        if (rayGunMax != 2)
        {
            Instantiate(rayGun, new Vector2(1, 1), Quaternion.identity);
            rayGunMax++;
        }
    }
}

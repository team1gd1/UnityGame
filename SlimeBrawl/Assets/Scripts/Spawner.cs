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
        Instantiate(rayGun, new Vector2(1, 1), Quaternion.identity);    
    }
}

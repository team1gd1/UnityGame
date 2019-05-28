using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public GameObject player;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Debug.Log("Collided With Weapon");
        }
    }
}

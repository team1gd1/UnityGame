using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2Health : MonoBehaviour
{
    bool isDead = false;
    public Slider playerHealth2;
    public int startingHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        takeDamage();
        Dead();
    }

    void takeDamage()
    {
        if (Input.GetKeyDown("z"))
        {
            currentHealth -= 50;
            playerHealth2.value = currentHealth;
        }

    }

    void Dead()
    {
        if (currentHealth <= 0 && isDead == false)
        {
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    bool isDead = false;
    public Slider playerHealth;
    public int startingHealth = 100;
    public int currentHealth;
    public GameObject player;
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
        if (Input.GetKeyDown("x"))
        {
            currentHealth -= 50;
            playerHealth.value = currentHealth;
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

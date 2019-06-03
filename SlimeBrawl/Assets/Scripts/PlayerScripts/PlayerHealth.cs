using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    bool isDead = false;
    public Slider playerHealth;

<<<<<<< HEAD
    public float startingHealth = 100;
    public float currentHealth;
    public GameObject player;
=======
    public GameObject player;

    public float startingHealth = 100;
    public float currentHealth;


>>>>>>> 918434b90890335c29146ff93782265e1b88fdaa

    public bool inCircle = false;

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
        if (inCircle)
        {
            currentHealth -= 1 * Time.deltaTime;
        }
        playerHealth.value = currentHealth;
       // playerHealth.value = currentHealth;
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

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shrinking")
        {
            inCircle = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shrinking")
        {
            inCircle = false;
        }
    }
}

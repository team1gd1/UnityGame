using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    bool isDead = false;
    public Slider playerHealth;

    public float startingHealth = 100;
    public float currentHealth;
    public GameObject player;

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

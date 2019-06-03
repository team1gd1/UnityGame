using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerGrow : MonoBehaviour
{

    public Slider playerSize;
    public float startingSize = 100;
    public float currentSize;
    public GameObject player;
    public float pixelsPerUnit;

    // Start is called before the first frame update
    void Start()
    {
        currentSize = startingSize;
        Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        grow();
    }

    void grow()
    {
        currentSize = player.gameObject.GetComponent<PlayerHealth>().currentHealth;
        player.transform.localScale = new Vector3(currentSize, currentSize);
    }
}

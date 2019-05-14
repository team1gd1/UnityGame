using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlatform : MonoBehaviour
{
    public long MaxSize = 400000000000000;
    private bool Growing = true; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Resize();
    }

    void Resize()
    {
        if (Growing == true)
        {
            transform.localScale += new Vector3(0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0);
        }
        else if (Growing == false)
        {
            transform.localScale -= new Vector3(0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlatSpot")
        {
            if (Growing == true)
            {
                Growing = false;
            }
            else if (Growing == false)
            {
                Growing = true;
            }
        }
    }
}

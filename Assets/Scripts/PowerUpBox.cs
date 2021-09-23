using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBox : MonoBehaviour
{
    public GameObject PowerUp;
    public int uses = 1;

    public bool brokenBox;
    public int timeDeley = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(uses != 0)
        {
            if (collision.tag == "Player")
            {
                if (brokenBox)
                {
                    InvokeRepeating("spawn", 0, timeDeley);
                }

                else
                {
                    spawn();
                }
                uses--;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Time int = 0;
        if(uses == 0)
        {
            Time.deltaTime
        }
        */
    }

    private void spawn()
    {
        Instantiate(PowerUp, transform.position + new Vector3(0, .5f, 0), transform.rotation);        
    }
}

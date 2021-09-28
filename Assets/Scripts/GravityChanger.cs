using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    //default values
    public float jump = 10;
    public float grav = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CharacterController_Geremy>().jumpForce = 10;
        collision.GetComponent<Rigidbody2D>().gravityScale = grav;
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    collision.GetComponent<CharacterController_Geremy>().jumpForce = 10;
    //    collision.GetComponent<Rigidbody2D>().gravityScale = 1;
    //}
}

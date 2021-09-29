using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_Geremy : MonoBehaviour
{
    public float moveSpeed = 2;
    public float jumpForce = 10;

    private Rigidbody2D rigidBd;
    private Collider2D collider;
    private bool scaleTooLarge = false;
    private Vector3 stayLocation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidBd = GetComponent<Rigidbody2D>();
        //collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //BasicMovement
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidBd.velocity.y) < 0.01f)
        {
            rigidBd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //Debug.Log("Jump button pressed");
        }

        //Scalling demo
        //*
        if (Input.GetKeyDown(KeyCode.G) == true)
        {
            //scaleUp();
        }

        //Debug.Log("Velocity.y = " + rigidBd.velocity.y);
        if (scaleTooLarge)
            this.transform.position = stayLocation;

        //*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
            Debug.Log("Goal reached!");

        else if (collision.tag == "PowerUp" )
        {
            //scaleUp();
        }
    }


    public void scaleUp()
    {
        transform.localScale *= 2;

        //*
        if (transform.localScale.x > 4)
        {
            rigidBd.constraints = RigidbodyConstraints2D.FreezeAll;
            scaleTooLarge = true;
            stayLocation = this.transform.position;
            float d = transform.localScale.x / 4;
            GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f / d);
            GetComponent<BoxCollider2D>().offset = Vector2.zero;
        }
        //*/
    }
}

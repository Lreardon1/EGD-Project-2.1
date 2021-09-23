using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLeith : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Vector2 input = Vector2.zero;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * input.x * moveSpeed * Time.deltaTime);

        if(jump)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        jump = false;
    }
}

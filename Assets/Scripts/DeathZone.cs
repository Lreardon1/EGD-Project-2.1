using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Vector3 respawnLocation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
            if(playerRB != null)
            {
                playerRB.velocity = Vector2.zero;
                playerRB.angularVelocity = 0f;
            }
            player.transform.rotation = Quaternion.identity;
            player.transform.position = respawnLocation;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public SpriteRenderer sr;
    public float moveDistance = 2.5f;

    private Vector2 origin;
    private float direction = -1;
    private DeathZone dz;

    // Start is called before the first frame update
    void Start()
    {
        dz = FindObjectOfType<DeathZone>();
    }

    private void Awake()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1)
            sr.flipX = true;
        else
            sr.flipX = false;
        transform.position += (transform.right * moveSpeed * direction * Time.deltaTime);
        if (Vector2.Distance(transform.position, origin) > moveDistance)
            direction = -direction;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
            playerRB.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
            this.gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
            if (playerRB != null)
            {
                playerRB.velocity = Vector2.zero;
                playerRB.angularVelocity = 0f;
            }
            player.transform.rotation = Quaternion.identity;
            player.transform.position = dz.respawnLocation;
        }
    }
}

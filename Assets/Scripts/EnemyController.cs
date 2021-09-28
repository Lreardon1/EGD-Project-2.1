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

    // Start is called before the first frame update
    void Start()
    {
        
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
}

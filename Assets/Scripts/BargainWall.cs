using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D),typeof(BoxCollider2D),typeof(Rigidbody2D))]
public class BargainWall : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    bool isInside = false;
    Vector2 targetVector;

    Rigidbody2D rb;
    PlayerController playerRef;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isInside)
        {
            targetVector.x = Input.GetAxis("Horizontal");
            targetVector.y = Input.GetAxis("Vertical");
        }
        else
        {
            targetVector = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!playerRef)
            {
                playerRef = collision.GetComponent<PlayerController>();
            }

            playerRef.enabled = false;
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!playerRef)
            {
                playerRef = collision.GetComponent<PlayerController>();
            }

            playerRef.enabled = true;
            isInside = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetVector * moveSpeed * Time.fixedDeltaTime);
    }

}

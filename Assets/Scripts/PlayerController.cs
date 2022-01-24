using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] bool isDepressed = false;
    [SerializeField] int depressMoveCount = 5;


    Rigidbody2D rb;
    Vector2 targetVector;
    int moveCounter = 0;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(isDepressed)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                moveCounter++;

            if (moveCounter % depressMoveCount == 0)
            {
                targetVector.x = Input.GetAxisRaw("Horizontal");
            }

        }
        else
        {
            targetVector.x = Input.GetAxisRaw("Horizontal");
            targetVector.y = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetVector * moveSpeed * Time.fixedDeltaTime);
    }
}

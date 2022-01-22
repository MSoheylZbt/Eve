using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;

    Rigidbody2D rb;
    Vector2 targetVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        targetVector.x = Input.GetAxisRaw("Horizontal");
        targetVector.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetVector * moveSpeed * Time.fixedDeltaTime);
    }
}

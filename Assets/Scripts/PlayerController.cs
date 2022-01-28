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


    bool isStarted = false;

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

            if (moveCounter != 0 && moveCounter % depressMoveCount == 0)
            {
                targetVector.x = Input.GetAxisRaw("Horizontal");
            }

        }
        else
        {
            if(isStarted)
            {
                targetVector.x = Input.GetAxisRaw("Horizontal");
                targetVector.y = Input.GetAxisRaw("Vertical");
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetVector * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(2f);
        isStarted = true;
    }

    private void OnDisable()
    {
        isStarted = false;
    }
}

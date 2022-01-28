using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D),typeof(BoxCollider2D))]
public class AngerWall : MonoBehaviour
{
    [SerializeField] int hitCount = 3;
    [SerializeField] float forceMultiplier = 20f;

    bool isInside = false;
    bool isHitted = false;
    int hitCounter = 0;

    Rigidbody2D playerRB;
    AudioSource audioSource;
    private Animator animator;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInside = true;
            if(!playerRB)
            {
                playerRB = collision.gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInside = false;
            isHitted = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isInside)
        {
            hitCounter++;
            animator.SetInteger("Hit", hitCounter);
            isHitted = true;
            audioSource.PlayOneShot(audioSource.clip);
        }
        if(hitCounter == hitCount)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(playerRB && isHitted)
            playerRB.AddForce(this.transform.up  * forceMultiplier);
    }
}

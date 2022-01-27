using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D),typeof(BoxCollider2D))]
public class AngerWall : MonoBehaviour
{
    [SerializeField] int hitCount = 3;
    [SerializeField] float forceMultiplier = 20f;

    bool isInside = false;
    int hitCounter = 0;
    Rigidbody2D playerRB;

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
            isInside = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isInside)
        {
            hitCounter++;
            isInside = false;
            //Vector2 forceDir = this.transform.position - collision.gameObject.transform.position;
            playerRB.AddForce(transform.forward * forceMultiplier);
        }

        if(hitCounter == hitCount)
        {
            gameObject.SetActive(false);
        }
    }

}

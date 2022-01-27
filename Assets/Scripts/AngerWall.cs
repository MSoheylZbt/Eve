using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D),typeof(BoxCollider2D))]
public class AngerWall : MonoBehaviour
{
    [SerializeField] int hitCount = 3;


    bool isInside = false;
    int hitCounter = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isInside = true;
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
        }

        if(hitCounter == hitCount)
        {
            gameObject.SetActive(false);
        }
    }

}

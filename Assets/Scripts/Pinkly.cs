using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinkly : MonoBehaviour
{
    ProgressManager managerRef;

    public void SetManagerRef(ProgressManager manager)
    {
        managerRef = manager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            managerRef.ActiveNextPinkly();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MultipleClickWall : MonoBehaviour
{
    [SerializeField] float clickTimeWindow = 0.5f;

    float elapsedTime = 0;
    bool isFirstClick = false;
    int doubleClickCount = 0;

    private void Update()
    {
        if(isFirstClick)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > clickTimeWindow)
            {
                isFirstClick = false;
                elapsedTime = 0;
            }
        }

    }

    private void OnMouseDown()
    {
        if(isFirstClick == false)
        {
            isFirstClick = true;
        } 
        else
        {
            isFirstClick = false;
            OnSecondClick();
        }
    }

    void OnSecondClick()
    {
        doubleClickCount++;
        if(doubleClickCount == 3)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ClickWall : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}

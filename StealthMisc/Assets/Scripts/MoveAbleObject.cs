using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbleObject : MonoBehaviour
{
    public string unitName;
    public Cursor cursor;
    public int movementRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cursor")
        {
            cursor.onObject = this;
            cursor.onTarget = true;
        }
    }
}

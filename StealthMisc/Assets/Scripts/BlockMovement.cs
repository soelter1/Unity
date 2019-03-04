using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{

    public Cursor cursor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cursor")
        {
            cursor.blocked = true;
        }
    }
}

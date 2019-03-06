using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbleObject : MonoBehaviour
{
    public string unitName = "";
    public Cursor cursor;
    public int movementRange = 0;
    public int atk = 0;
    public int hp = 1;
    public int player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cursor")
        {
            cursor.onObject = this;
            cursor.onTarget = true;
        }
    }

    Vector3 targetPos;
    bool moving = false;
    public BoxCollider boxcol;

    public void Move(float x, float z)
    {
        targetPos = new Vector3(x, transform.position.y, z);
        float t = Mathf.MoveTowards(transform.position.x, x, movementRange);
        moving = true;
        boxcol.isTrigger = true;
    }

    public void Attack(MoveAbleObject target)
    {
        Debug.Log("pewpewpew");
    }

    void Update()
    {
        if (targetPos == transform.position) { moving = false; boxcol.isTrigger = false; }
        if (moving&& (targetPos.x != transform.position.x))
        {
            float newX = Mathf.MoveTowards(transform.position.x, targetPos.x, movementRange);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        if(moving && (targetPos.x == transform.position.x) && (targetPos.z != transform.position.z))
        {
            float newZ = Mathf.MoveTowards(transform.position.z, targetPos.z, movementRange);
            transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;


public class MoveAbleObject : MonoBehaviour
{
    public KingScript isKing = null;
    public Cursor cursor;
    public InfantryScript isInf = null;
    
    public LethalProjectileBehaviourScript lethalProjectile;
    public NonLethalProjectileBehaviourScript nonLethalProjectile;

    public AudioSource moveSound;
    public AudioSource attackSound;

    public string unitName = "";
    public string unitDescr = "";
    public int movementRange = 0;
    public int attackRange = 0;
    public int atk = 0;
    public int hp = 1;
    public int player;

    public bool hasMoved = false;
    public bool hasAttacked = false;

    public Vector3 eulerAngles;

    void Start()
    {
        attackRange = movementRange + atk;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cursor")
        {
            cursor.onObject = this;
            cursor.onTarget = true;
        }
    }

    private bool posInRange(Vector3 target, int range)
    {
        return (  System.Math.Abs(transform.position.x - target.x) 
                + System.Math.Abs(transform.position.z - target.z) <= range * 10);  //Manhattan Distance
    }

    Vector3 targetPos;
    bool moving = false;
    public BoxCollider boxcol;

    public void Move(float x, float z)
    {
        if (posInRange(new Vector3(x, 0, z), movementRange) && !hasMoved)
        {
            if(moveSound!=null) moveSound.Play();
            targetPos = new Vector3(x, transform.position.y, z);
            float t = Mathf.MoveTowards(transform.position.x, x, movementRange);
            moving = true;
            boxcol.isTrigger = true;
            hasMoved = true;
        }
    }

    public void Attack(MoveAbleObject target)
    {
        eulerAngles = transform.rotation.eulerAngles;
        Vector3 targetEulerAngles = target.GetComponent<Transform>().transform.eulerAngles;

        if (posInRange(target.transform.position, atk) && !hasAttacked && target.player != player) {
            if (attackSound != null) attackSound.Play();
            Debug.Log(name + " :pewpewpew");

            gameObject.transform.LookAt(target.transform.position);
            gameObject.transform.Rotate(eulerAngles);

            if (target.hp - 1 <= 0)
            {
                lethalProjectile.enabled = true;
            }
            else
            {
                nonLethalProjectile.enabled = true;
            }

            target.getsDamaged(this);
            hasAttacked = true;
        }
        if(isInf != null && target == this) { Debug.Log("Im Inf!");  }
    }

    void getsDamaged(MoveAbleObject attacker)
    {
        Debug.Log(name + " :I got hit!");
        hp -= 1;
        if(hp <= 0)
        {
            if (isKing != null) isKing.theKingIsDeadLongLiveTheKing(attacker.player);
            //destruction x seconds after projectile impact in DestroyBehaviourScript
        }
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

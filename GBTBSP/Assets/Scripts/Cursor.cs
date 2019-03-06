﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cursor : MonoBehaviour
{

    public MoveAbleObject selectedTarget;
    public MoveAbleObject onObject;
    public SelectedUI selectedUI;
    public GridBehaviourScript grid;

    public int gridsizeX;
    public int gridsizeZ;

    bool targetSelected = false;

    public bool onTarget = false;
    public bool blocked = false;

    private bool selectedCollision = false;

    private void selectTarget()
    {
        selectedTarget = onObject;
        targetSelected = true;
        selectedUI.UpdateTo(selectedTarget);
    }

    private void disselectTarget()
    {
        selectedTarget = null;
        targetSelected = false;
        selectedUI.UpdateToNone();
    }

    public bool isReachable(Vector3 destination)
    {
        Vector3[] reachable = grid.movementRangeArray;

        if (Array.Exists<Vector3>(reachable, element => element == destination)) return true;
        else return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SelectedFloor")
        {
            selectedCollision = true;
            Debug.Log("I collide");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown("w") && !(transform.position.z == (gridsizeZ*10)))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position+(new Vector3(0, 0, 10f)));
        }
        if (Input.GetKeyDown("s") && !(transform.position.z == 0f))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(0, 0, -10f)));
        }
        if (Input.GetKeyDown("a") && !(transform.position.x == 0f))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(-10f,0,0)));
        }
        if (Input.GetKeyDown("d") && !(transform.position.x == (gridsizeX*10f)))
        {
            onTarget = false;
            blocked = false;
            transform.position = (transform.position + (new Vector3(10f, 0, 0)));
        }
        if (Input.GetKeyDown("space") && targetSelected && !(blocked || onTarget))
        {

            if(selectedCollision)       //selectedFloor Prefab collides with Cursor
            {
                selectedTarget.transform.position = new Vector3(transform.position.x, selectedTarget.transform.position.y, transform.position.z);

                selectedCollision = !selectedCollision;
            }
        }
        if (Input.GetKeyDown("f"))
        {
            if (onTarget)
            {
                Debug.Log("On Target");

                selectTarget();
                grid.ShowMovementRange(selectedTarget, true);
            }
            else
            {
                Debug.Log("Not on Target");

                selectTarget();
                grid.ShowMovementRange(selectedTarget, false);

                disselectTarget();
            }
        }
    }

}

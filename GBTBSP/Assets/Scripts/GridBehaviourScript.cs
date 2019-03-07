using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridBehaviourScript : MonoBehaviour
{
    FloorBehaviourScript[] floors;

    public GameObject RangeFloorGrid;
    public GameObject AttackFloorGrid;

    public Vector3[] movementRangeArray;
    public Vector3[] attackRangeArray;

    int moveCounter = 0;
    int attackCounter = 0;

    //calculates the ArraySize
    int ArraySize(int movementRange)
    {
        int arraySize = 0;

        for (int i = 1; i <= movementRange; i++)
        {
            arraySize = arraySize + i;
        }
        return (arraySize * 4 + 1);
    }

    public void ShowMovementRange(MoveAbleObject obj, bool state)
    {
        int movementRange = obj.movementRange;

        int movementRangeArraySize = ArraySize(movementRange);

        floors = GetComponentsInChildren<FloorBehaviourScript>();   //Array mit floors

        Vector3 objPos = obj.transform.position;        //Curserd Object Position

        GameObject[] floorsInRange = new GameObject[ArraySize(movementRange)];

        movementRangeArray = new Vector3[movementRangeArraySize];

        foreach (FloorBehaviourScript i in floors)
        {
            Vector3 floorPos = i.transform.position;

            float manhattan = Math.Abs(objPos.x - floorPos.x) + Math.Abs(objPos.z - floorPos.z);  //Manhattan Distance

            if (manhattan <= movementRange * 10)
            {
                //activate Range
                if (state)
                {
                    Instantiate(RangeFloorGrid, new Vector3(floorPos.x, 1.0f, floorPos.z), Quaternion.identity);     //generates selectedFloor Prefab
                    movementRangeArray[moveCounter] = floorPos;         //adds reachable Position to an array
                    //Debug.Log(floorPos + " is reachable");
                    moveCounter++;
                }
                //deactivate Range
                else
                {
                    floorsInRange = GameObject.FindGameObjectsWithTag("RangeFloor");    //Array of all selectedFloor Prefab Objects

                    foreach (GameObject go in floorsInRange)
                    {
                        Destroy(go);            //Destroys them all
                    }
                }
            }
        }
        moveCounter = 0;
    }

    public void ShowAttackRange(MoveAbleObject obj, bool state)
    {
        int attackRange = obj.attackRange;
        if (obj.hasMoved) attackRange = obj.attackRange - obj.movementRange;
        int attackRangeArraySize = ArraySize(attackRange);

        floors = GetComponentsInChildren<FloorBehaviourScript>();   //Array mit floors

        Vector3 objPos = obj.transform.position;        //Curserd Object Position

        GameObject[] attackableFloors = new GameObject[ArraySize(attackRange)];

        attackRangeArray = new Vector3[attackRangeArraySize];

        foreach (FloorBehaviourScript i in floors)
        {
            Vector3 floorPos = i.transform.position;

            float manhattan = Math.Abs(objPos.x - floorPos.x) + Math.Abs(objPos.z - floorPos.z);  //Manhattan Distance

            if (manhattan <= attackRange * 10)
            {
                //activate Range
                if (state)
                {
                    Instantiate(AttackFloorGrid, new Vector3(floorPos.x, 0.9f, floorPos.z), Quaternion.identity);     //generates selectedFloor Prefab
                    attackRangeArray[attackCounter] = floorPos;         //adds reachable Position to an array
                    attackCounter++;
                }
                //deactivate Range
                else
                {
                    attackableFloors = GameObject.FindGameObjectsWithTag("AttackFloor");    //Array of all selectedFloor Prefab Objects

                    foreach (GameObject go in attackableFloors)
                    {
                        Destroy(go);            //Destroys them all
                    }
                }
            }
        }
        attackCounter = 0;
    }
}
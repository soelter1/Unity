using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridBehaviourScript : MonoBehaviour
{
    FloorBehaviourScript[] floors;

    public GameObject selectedFloor;

    public Vector3[] movementRangeArray;

    int counter = 0;

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

        GameObject[] selectedFloors = new GameObject[ArraySize(movementRange)];

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
                    Instantiate(selectedFloor, new Vector3(floorPos.x, 1.0f, floorPos.z), Quaternion.identity);     //generates selectedFloor Prefab
                    Debug.Log(floorPos + " is reachable");
                    movementRangeArray[counter] = floorPos;         //adds reachable Position to an array
                    counter++;
                }
                //deactivate Range
                else
                {
                    selectedFloors = GameObject.FindGameObjectsWithTag("SelectedFloor");    //Array of all selectedFloor Prefab Objects

                    foreach (GameObject go in selectedFloors)
                    {
                        Destroy(go);            //Destroys them all

                        Debug.Log(go.transform.position + " not reachable!");
                    }
                }
            }
        }

        foreach (Vector3 v in movementRangeArray)
        {
            Debug.Log(v + " is reachable Array");
        }


        counter = 0;
    }
}
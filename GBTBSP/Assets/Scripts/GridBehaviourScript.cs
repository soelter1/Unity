using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridBehaviourScript : MonoBehaviour
{
    public FloorBehaviourScript[] floors;

    MeshRenderer rend;

    public Material Ground1;
    public Material Ground2;
    public Material Range;

    int counter = 0;

    public ArrayList MakeMovementRangeArray(MoveAbleObject obj)
    {
        int movementRange = obj.movementRange;

        int movementRangeArraySize = ArraySize(movementRange);

        Debug.Log("mras" + movementRangeArraySize);

        Vector3[] movementRangeArray = new Vector3[movementRangeArraySize];
        ArrayList movementRangeArrayList = new ArrayList();

        Debug.Log("mral" + movementRangeArray.Length);

        floors = GetComponentsInChildren<FloorBehaviourScript>();   //Array mit floors

        Vector3 objPos = obj.transform.position;        //Curserd Object Position

        foreach (FloorBehaviourScript i in floors)
        {
            Vector3 floorPos = i.transform.position;

            float manhatten = Math.Abs(objPos.x - floorPos.x) + Math.Abs(objPos.z - floorPos.z);

            if (manhatten <= movementRange * 10 && counter < movementRangeArraySize)
            {
                movementRangeArrayList.Add(floorPos);
                //movementRangeArray[counter++] = floorPos;
                //Debug.Log("florPos from mmra" + floorPos);
            }
        }

        //return movementRangeArray;
        return movementRangeArrayList;
    }

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

    public void ShowMovementRangeDirectly(MoveAbleObject obj)
    {
        int movementRange = obj.movementRange;

        int movementRangeArraySize = ArraySize(movementRange);

        Vector3[] movementRangeArray = new Vector3[movementRangeArraySize];

        floors = GetComponentsInChildren<FloorBehaviourScript>();   //Array mit floors

        Vector3 objPos = obj.transform.position;        //Curserd Object Position

        foreach (FloorBehaviourScript i in floors)
        {
            Vector3 floorPos = i.transform.position;

            float manhatten = Math.Abs(objPos.x - floorPos.x) + Math.Abs(objPos.z - floorPos.z);
            
            if (manhatten <= movementRange * 10 && counter < movementRangeArraySize)
            {
                rend = i.GetComponent<MeshRenderer>();

                rend.material = Range;

                Debug.Log(counter);

                counter++;
            }
        }
    }

    public void ShowMovementRange(MoveAbleObject obj, bool reverse)
    {
        int movementRange = obj.movementRange;

        int movementRangeArraySize = ArraySize(movementRange);

        //Vector3[] movementRangeArray = MakeMovementRangeArray(obj);

        ArrayList movementRangeArrayList = MakeMovementRangeArray(obj);

        foreach (Vector3 v in movementRangeArrayList)
        {
            Debug.Log(v);
        }

        //Debug.Log(movementRangeArray.Length);

        foreach (FloorBehaviourScript i in floors)
        {
            Vector3 floorPos = i.transform.position;

            /*

            if (Array.Exists(movementRangeArray, element => element == new Vector3(floorPos.x, 0, floorPos.z)))
            {
                //Debug.Log("Floor x = " + floorPos.x + ", z = " + floorPos.z + " is reachable! " + movementRangeArray.Length);
                rend = i.GetComponent<MeshRenderer>();

                rend.material = Range;
            }

    */
            rend = i.GetComponent<MeshRenderer>();

            Material memory = rend.material;

            if (movementRangeArrayList.Contains(new Vector3(floorPos.x, 0, floorPos.z)))
            {

                if (!reverse) {
                    rend.material = Range;
                }

                if (reverse)
                {
                    rend.material = memory;
                }
            }
        }
    }
}
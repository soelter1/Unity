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

    public void showMovementRange(MoveAbleObject obj)
    {
        Debug.Log(obj.transform.position);

        floors = GetComponentsInChildren<FloorBehaviourScript>();   //Array mit floors

        Debug.Log(floors.Length);

        Vector3 objPos = obj.transform.position;

        int movementRange = obj.movementRange;

        int primeRange = movementRange * 2 + 1;

        Debug.Log("movementRange: " + movementRange + ", primeRange: " + primeRange);

        Vector3[] reachable = MakeRangeArray(objPos, movementRange, primeRange);

        foreach (FloorBehaviourScript i in floors)
        {

            if (Array.Exists(reachable, element => element.Equals(i.transform.position)))
            {
                Debug.Log(i + "is reachable!");
                rend = i.GetComponent<MeshRenderer>();

                rend.material = Range;
            }
        }
    }

    //calculates the ArraySize
    int ArraySize(int movementRange)
    {
        int arraySize = 0;

        for(int i = 1; i <= movementRange; i++)
        {
            arraySize += i;
            Debug.Log("arraySize: " + arraySize);
        }
        return arraySize * 4 + 1;
    }

    Vector3[] MakeRangeArray(Vector3 objPos, int movementRange, int primeRange)
    {
        int arraySize = ArraySize(movementRange);

        Vector3[] rangeArray = new Vector3[arraySize];

        Debug.Log("rangeArray Length: " + rangeArray.Length);

        int diagonals = 12;

        Debug.Log("diagonals: " + diagonals);

        for (int i = 0; i < movementRange; i++)
        {

            //TODO: Manhatten distance

            rangeArray[0] = new Vector3(objPos.x, 0, objPos.z);
            rangeArray[1+i*4] = new Vector3(objPos.x, 0, objPos.z + ((i+1) * 10));
            rangeArray[2+i*4] = new Vector3(objPos.x, 0, objPos.z - ((i + 1) * 10));
            rangeArray[3+i*4] = new Vector3(objPos.x + ((i + 1) * 10), 0, objPos.z);
            rangeArray[4+i*4] = new Vector3(objPos.x - ((i + 1) * 10), 0, objPos.z);

            

            for (int d = diagonals; d > 0; d--)
            {
                rangeArray[arraySize - d] = new Vector3(objPos.x + (i * 10), 0, objPos.z + (i * 10));
                rangeArray[arraySize - d] = new Vector3(objPos.x - (i * 10), 0, objPos.z - (i * 10));
                rangeArray[arraySize - d] = new Vector3(objPos.x - (i * 10), 0, objPos.z + (i * 10));
                rangeArray[arraySize - d] = new Vector3(objPos.x + (i * 10), 0, objPos.z - (i * 10));

            }

   
            

            Debug.Log("u do shit?");
        }

        return rangeArray;
    }
}
